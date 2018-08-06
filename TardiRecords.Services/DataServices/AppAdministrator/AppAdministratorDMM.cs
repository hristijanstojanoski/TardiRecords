using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TardiRecords.Services.Helpers;
using System.Data;
using TardiRecords.DataLayer;
using TardiRecords.Services.DataModels;

namespace TardiRecords.Services.DataServices.AppAdministrator
{
    public class AppAdministratorDMM
    {
        public static ActionHandler InsertOrUpdateRecordType(RecordTypeDM record)
        {
            ActionHandler result = new ActionHandler { IsSuccess = true, Message = "" };
            try
            {
                using (TardiRecordsEntities db = new DataLayer.TardiRecordsEntities())
                {
                    var item = db.RecordType.SingleOrDefault(x => x.id == record.Id);
                    if (item == null)
                    {
                        RecordType RT = new RecordType();
                        RT.id = record.Id;
                        RT.isDeleted = false;
                        RT.isEnabled = true;
                        RT.name = record.Name;
                        RT.subType = record.SubType;
                        RT.createdBy = record.CreatedBy;
                        RT.createdDate = DateTime.Now;
                        RT.modifiedBy = record.ModifiedBy;
                        RT.modifyDate = DateTime.Now;
                        db.RecordType.Add(RT);
                        db.SaveChanges();
                    }
                    else
                    {
                        item.name = record.Name;
                        item.subType = record.SubType;
                        item.modifiedBy = record.ModifiedBy;
                        item.modifyDate = DateTime.Now;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ActionHandler ChangeRecordTypeActiveStatus(Guid id, string loggedUserId)
        {
            ActionHandler result = new ActionHandler { IsSuccess = true, Message = "" };
            try
            {
                using (TardiRecordsEntities db = new DataLayer.TardiRecordsEntities())
                {
                    var item = db.RecordType.SingleOrDefault(x => x.id == id);
                    if (item != null)
                    {
                        if (item.isEnabled)
                        {
                            item.isEnabled = false;
                        }
                        else
                        {
                            item.isEnabled = true;
                        }
                        item.modifiedBy = loggedUserId;
                        item.modifyDate = DateTime.Now;
                        db.SaveChanges();
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Message = "Item not found!";
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ActionHandler DeleteRecordType(Guid id, string loggedUserId)
        {
            ActionHandler result = new ActionHandler { IsSuccess = true, Message = "" };
            try
            {
                using (TardiRecordsEntities db = new DataLayer.TardiRecordsEntities())
                {
                    var item = db.RecordType.SingleOrDefault(x => x.id == id);
                    if (item != null)
                    {
                        item.isDeleted = true;
                        item.modifiedBy = loggedUserId;
                        item.modifyDate = DateTime.Now;
                        db.SaveChanges();
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Message = "Item not found!";
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static List<RecordTypeTableViewDM> GetAllRecordTypes()
        {
            List<RecordTypeTableViewDM> result = new List<RecordTypeTableViewDM>();
            using (TardiRecordsEntities db = new DataLayer.TardiRecordsEntities())
            {
                var items = db.RecordType.Where(x => x.isDeleted == false && x.isEnabled == true);
                if (items != null)
                {
                    foreach (var i in items)
                    {
                        RecordTypeTableViewDM li = new RecordTypeTableViewDM();
                        li.Id = i.id;
                        li.SubtypeId = i.subType;
                        li.SubtypeName = Helpers.EnumHelper.GetEnumDescription((Enums.RecordSubTypeEnum)i.subType);
                        li.TypeName = i.name;
                        li.CreatedBy = i.createdBy;
                        li.CreatedOn = i.createdDate;
                        li.UpdatedBy = i.modifiedBy;
                        li.UpdatedOn = i.modifyDate;
                        result.Add(li);
                    }
                }
            }
            return result;
        }

        public static List<UsersDM> GetAllUsers()
        {
            List<UsersDM> result = new List<UsersDM>();
            using (TardiRecordsEntities db = new DataLayer.TardiRecordsEntities())
            {
                var items = db.vw_AllUsers;
                foreach (var item in items)
                {
                    UsersDM u = new UsersDM();
                    u.AppUserId = item.AppUserId;
                    u.AspNetUserId = item.AspNetUserId;
                    u.FirstName = item.firstName;
                    u.LastName = item.lastName;
                    u.Email = item.Email;
                    u.IsLocked = item.LockoutEnabled;
                    u.LastChangedOn = item.modifyDate;
                    u.LastChangedBy = item.EditedBy;
                    u.Position = item.position;
                    result.Add(u);
                }
            }
            return result;
        }

        public static ActionHandler CreateUser(string eMail, string firstName, string lastName, string position, string currentUser)
        {
            ActionHandler result = new ActionHandler();
            try
            {
                using (TardiRecordsEntities db = new DataLayer.TardiRecordsEntities())
                {
                    var registeredUser = db.AspNetUsers.Where(x => x.Email == eMail).SingleOrDefault();
                    registeredUser.LockoutEnabled = false;
                    AppUsers u = new AppUsers();
                    u.id = Guid.NewGuid();
                    u.aspNetUserId = registeredUser.Id;
                    u.createdBy = currentUser;
                    u.createdDate = DateTime.Now;
                    u.firstName = firstName;
                    u.lastName = lastName;
                    u.modifyBy = currentUser;
                    u.modifyDate = DateTime.Now;
                    u.position = position;
                    db.AppUsers.Add(u);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ActionHandler LockUnlockUser(string aspNetMemberId, string loggedUser)
        {
            ActionHandler result = new ActionHandler();
            try
            {
                using (TardiRecordsEntities db = new DataLayer.TardiRecordsEntities())
                {
                    var aspNetUser = db.AspNetUsers.Where(x => x.Id == aspNetMemberId).SingleOrDefault();
                    var appUser = db.AppUsers.Where(x => x.aspNetUserId == aspNetMemberId).SingleOrDefault();
                    if (aspNetUser.LockoutEnabled)
                    {
                        aspNetUser.LockoutEnabled = false;
                    }
                    else
                    {
                        aspNetUser.LockoutEnabled = true;
                    }
                    appUser.modifyBy = loggedUser;
                    appUser.modifyDate = DateTime.Now;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}

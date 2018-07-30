using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TardiRecords.DataLayer;
using TardiRecords.Services.DataModels;
using TardiRecords.Services.Helpers;

namespace TardiRecords.Services.DataServices.MainUser
{
    public class MainUserDMM
    {
        public static ActionHandler InsertOrUpdateRecordList(RecordListDM recordList)
        {
            ActionHandler result = new ActionHandler { IsSuccess = true, Message = "" };
            try
            {
                using (TardiRecordsEntities db = new DataLayer.TardiRecordsEntities())
                {
                    var item = db.RecordList.SingleOrDefault(x => x.id == recordList.Id);
                    if (item == null)
                    {
                        RecordList RL = new RecordList();
                        RL.id = recordList.Id;
                        RL.title = recordList.Title;
                        RL.recordTypeId = recordList.RecordTypeId;
                        RL.createdBy = recordList.CreatedBy;
                        RL.createdDate = DateTime.Now;
                        RL.modifyBy = recordList.ModifyBy;
                        RL.modifyDate = DateTime.Now;
                        db.RecordList.Add(RL);
                        db.SaveChanges();
                    }
                    else
                    {
                        item.title = recordList.Title;
                        item.recordTypeId = recordList.RecordTypeId;
                        item.modifyBy = recordList.ModifyBy;
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

        public static ActionHandler DeleteRecordList(Guid id, string createdBy)
        {
            ActionHandler result = new ActionHandler { IsSuccess = true, Message = "" };
            try
            {
                using (TardiRecordsEntities db = new DataLayer.TardiRecordsEntities())
                {
                    var item = db.RecordList.SingleOrDefault(x => x.id == id);
                    if (item != null)
                    {
                        item.createdBy = createdBy;
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

        public static List<RecordTypeTableViewDM> GetAllRecordList(Guid id)
        {
            List<RecordTypeTableViewDM> result = new List<RecordTypeTableViewDM>();
            using (TardiRecordsEntities db = new DataLayer.TardiRecordsEntities())
            {
                var items = db.RecordType.ToList();
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
    }
}

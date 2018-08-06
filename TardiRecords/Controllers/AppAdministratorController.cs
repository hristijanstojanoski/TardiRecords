using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using TardiRecords.Models;
using TardiRecords.Services.DataModels;
using TardiRecords.Services.DataViewModels;
using System.Threading.Tasks;
using System.Globalization;
using System.Security.Claims;
using TardiRecords.Services.Helpers;

namespace TardiRecords.Controllers
{
    public class AppAdministratorController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AppAdministratorController() { }
        public AppAdministratorController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSubtypes()
        {
            var result = Services.Helpers.EnumHelper.GetAllRecordSubTypeEnumInList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RecordTypes()
        {
            return View();
        }

        public ActionResult AllUsers()
        {
            return View();
        }

        public ActionResult AllMachines()
        {
            return View();
        }

        public ActionResult GetRecordTypesObjectsAndData()
        {
            RecordTypeNgVM obj = new RecordTypeNgVM();
            try
            {
                obj.SubtypeList = Services.Helpers.EnumHelper.GetAllRecordSubTypeEnumInList();
                obj.RecordsList = Services.DataServices.AppAdministrator.AppAdministratorDMM.GetAllRecordTypes();
                obj.Success.IsSuccess = true;
            }
            catch (Exception ex)
            {
                obj.Success.IsSuccess = false;
                obj.Success.Message = ex.Message;
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllUsersData()
        {
            UsersNgVM obj = new UsersNgVM();
            try
            {
                obj.AllUsers = Services.DataServices.AppAdministrator.AppAdministratorDMM.GetAllUsers();
                obj.Success.IsSuccess = true;
            }
            catch (Exception ex)
            {
                obj.Success.IsSuccess = false;
                obj.Success.Message = ex.Message;
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddOrUpdateRecordType(Guid? id, string typeName, int subTypeId)
        {
            Guid UID = Guid.NewGuid();
            if (id != null) { UID = (Guid)id; }
            RecordTypeDM newRecord = new RecordTypeDM()
            {
                Id = UID,
                CreatedBy = User.Identity.GetUserId(),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                IsEnabled = true,
                ModifiedBy = User.Identity.GetUserId(),
                ModifyDate = DateTime.Now,
                Name = typeName,
                SubType = subTypeId
            };

            var result = Services.DataServices.AppAdministrator.AppAdministratorDMM.InsertOrUpdateRecordType(newRecord);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RecordTypeChangeActive(Guid id)
        {
            var result = Services.DataServices.AppAdministrator.AppAdministratorDMM.ChangeRecordTypeActiveStatus(id, User.Identity.GetUserId());
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteRecordType(Guid id)
        {
            var result = Services.DataServices.AppAdministrator.AppAdministratorDMM.DeleteRecordType(id, User.Identity.GetUserId());
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult LockUnlockUser(string id)
        {
            var result = Services.DataServices.AppAdministrator.AppAdministratorDMM.LockUnlockUser(id, User.Identity.GetUserId());
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewUser(string firstName, string lastName, string eMail, string workPosition)
        {
            ActionHandler ah = new ActionHandler();
            try
            {
                var user = new ApplicationUser { UserName = eMail, Email = eMail };
                var result = await UserManager.CreateAsync(user, "P@$$w0rd");
                if (result.Succeeded)
                {
                    ah = Services.DataServices.AppAdministrator.AppAdministratorDMM.CreateUser(eMail, firstName, lastName, workPosition, User.Identity.GetUserId());
                }
                else
                {
                    ah.IsSuccess = false;
                    ah.Message = "User is not added into AspNetMembers";
                }
            }
            catch (Exception ex)
            {
                ah.IsSuccess = false;
                ah.Message = ex.Message;
            }
            return Json(ah, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserToRole(string username, List<string> roles)
        {
            ActionHandler ah = new ActionHandler();
            try
            {
                var allRoles= ((ClaimsIdentity)User.Identity).Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
                // Microsoft.AspNet.Identity.EntityFramework.IdentityRole role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            }
            catch (Exception ex)
            {
                ah.IsSuccess = false;
                ah.Message = ex.Message;
            }
            return Json(ah, JsonRequestBehavior.AllowGet);
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}
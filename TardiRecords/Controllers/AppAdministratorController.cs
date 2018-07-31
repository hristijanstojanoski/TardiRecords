using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TardiRecords.Services.DataModels;
using TardiRecords.Services.DataViewModels;

namespace TardiRecords.Controllers
{
    public class AppAdministratorController : Controller
    {
        // GET: AppAdministrator
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
    }
}
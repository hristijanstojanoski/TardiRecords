using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TardiRecords.Services.DataViewModels;

namespace TardiRecords.Controllers
{
    public class MainUserController : Controller
    {
        // GET: MainUser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult GetRecordListsObjectsAndData()
        {
            RecordListNgVM obj = new RecordListNgVM();
            try
            {
               
                obj.RecordsList = Services.DataServices.MainUser.MainUserDMM.GetAllRecordList();
                obj.Success.IsSuccess = true;
            }
            catch (Exception ex)
            {
                obj.Success.IsSuccess = false;
                obj.Success.Message = ex.Message;
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}
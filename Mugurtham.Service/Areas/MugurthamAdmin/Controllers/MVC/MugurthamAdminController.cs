using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mugurtham.Service.Controllers;
using Mugurtham.Common.Utilities;

namespace Mugurtham.Service.Areas.MugurthamAdmin.Controllers.MVC
{
    [MugurthamAuthorizeAttribute(Mugurtham.Core.Constants.RoleIDForMugurthamAdmin)]
    public class MugurthamAdminController : MugurthamBaseController
    {
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Profiles()
        {
            return View();
        }
    }
}

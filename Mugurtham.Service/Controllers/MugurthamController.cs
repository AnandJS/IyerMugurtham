using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mugurtham.Common.Utilities;

namespace Mugurtham.Service.Controllers
{
    [MugurthamAuthorizeAttribute(Mugurtham.Core.Constants.RoleIDForSangamAdmin, Mugurtham.Core.Constants.RoleIDForUserProfile, Mugurtham.Core.Constants.RoleIDForMugurthamAdmin)]
    public class MugurthamController : MugurthamBaseController
    {
        //
        // GET: /Mugurtham/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
            //return RedirectToAction("Home", "User/User");
        }

        public ActionResult Info()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mugurtham.Service.Controllers;
using Mugurtham.Common.Utilities;

namespace Mugurtham.Service.Areas.View.Controllers
{
    [MugurthamAuthorizeAttribute(Mugurtham.Core.Constants.RoleIDForSangamAdmin,
                                Mugurtham.Core.Constants.RoleIDForUserProfile,
                                Mugurtham.Core.Constants.RoleIDForMugurthamAdmin)]
    public class FullViewController : MugurthamBaseController
    {
        public ActionResult FullView(string ID)
        {
            return View();
        }
        [HttpGet]
        public ActionResult getProfileByProfileID(string ID)
        {
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            Mugurtham.Core.Profile.API.ProfileCore objProfileCoreForView = null;
            Mugurtham.Core.Profile.API.ProfileCore objProfileCore = new Mugurtham.Core.Profile.API.ProfileCore();
            using (objProfileCore as IDisposable)
                objProfileCore.GetByProfileID(ID, out objProfileCoreForView, objLoggedIn);
            objProfileCore = null;
            // Try to change the below implementation as it is possible of JSON HiJacking -- Anand J
            return this.Json(objProfileCoreForView, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getIsInterestedProfile(string ID)
        {
            bool isInterestedProfile = false;
            int intInterestedProfile = 0; // 0 -> Not an interested Profile; 1 -> is an interested profile
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            Mugurtham.Core.ProfileInterested.ProfileInterestedCore objProfileInterestedCore = new Core.ProfileInterested.ProfileInterestedCore();
            using (objProfileInterestedCore as IDisposable)
                isInterestedProfile = objProfileInterestedCore.isInterestedProfile(objLoggedIn.LoginID, ID);
            objProfileInterestedCore = null;
            if (isInterestedProfile)
                intInterestedProfile = 1;
            // Try to change the below implementation as it is possible of JSON HiJacking -- Anand J
            return this.Json(intInterestedProfile, JsonRequestBehavior.AllowGet);
        }
    }
}

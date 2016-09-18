using Mugurtham.Core.Profile.API;
using Mugurtham.Core.Profile.View;
using Mugurtham.Core.ProfileInterested;
using Mugurtham.Service.App_Code.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mugurtham.Common.Utilities;
using Mugurtham.Service.Controllers;

namespace Mugurtham.Service.Areas.Search.Controllers
{
    [MugurthamAuthorizeAttribute(Mugurtham.Core.Constants.RoleIDForSangamAdmin,
                              Mugurtham.Core.Constants.RoleIDForUserProfile,
                              Mugurtham.Core.Constants.RoleIDForMugurthamAdmin)]
    public class SearchController : MugurthamBaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProfileID()
        {
            return View();
        }

        public ActionResult AllProfiles()
        {
            return View();
        }

        public ActionResult GeneralSearch()
        {
            return View();
        }

        public ActionResult SangamSearch()
        {
            return View();
        }
        [HttpGet]
        public ActionResult getAllProfiles()
        {
            string strGender = "admin"; // Mugurtham admin, Sangam admin, public user
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            if (objLoggedIn.roleID == "F62DDFBE55448E3A3") // User Profiles 
            {
                if (!string.IsNullOrWhiteSpace(objLoggedIn.BasicInfoCoreEntity.Gender))
                {
                    if (objLoggedIn.BasicInfoCoreEntity.Gender.ToLower().Trim() == "male".ToLower().Trim())
                        strGender = "female";
                    else
                        strGender = "male";
                }
            }
            //string cs = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringName"].ConnectionString;
            ProfileBasicViewEntity objProfileBasicViewEntity = new ProfileBasicViewEntity();
            PorfileBasicInfoViewCore objPorfileBasicInfoViewCore = new PorfileBasicInfoViewCore();
            using (objPorfileBasicInfoViewCore as IDisposable)
            {
                objPorfileBasicInfoViewCore.GetAllProfiles(Utility.connectionString(), strGender,
                    ref objProfileBasicViewEntity,
                    ref objLoggedIn
                    );
            }
            objPorfileBasicInfoViewCore = null;
            //Uncommented the below code for performance optimization - Apr 11 2016 - Anand J
            /*
            List<ProfileCore> objProfileCoreList = new List<ProfileCore>();
            ProfileCore objProfileCore = new ProfileCore();
            using (objProfileCore as IDisposable)
                objProfileCore.GetAll(ref objProfileCoreList, strGender, objLoggedIn.sangamID);
            objProfileCore = null;*/
            //Response.AddHeader("Content-Encoding", "gzip");
            return this.Json(objProfileBasicViewEntity, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetRecentlyJoinedProfiles()
        {
            string strGender = "admin"; // Mugurtham admin, Sangam admin, public user
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            if (objLoggedIn.roleID == "F62DDFBE55448E3A3") // User Profiles 
            {
                if (!string.IsNullOrWhiteSpace(objLoggedIn.BasicInfoCoreEntity.Gender))
                {
                    if (objLoggedIn.BasicInfoCoreEntity.Gender.ToLower().Trim() == "male".ToLower().Trim())
                        strGender = "female";
                    else
                        strGender = "male";
                }
            }
            ProfileCore objProfileCore = new ProfileCore();
            ProfileBasicViewEntity objProfileBasicViewEntity = new ProfileBasicViewEntity();
            using (objProfileCore as IDisposable)
                objProfileCore.GetRecentlyJoinedProfiles(Utility.connectionString(), strGender,
                    objLoggedIn.sangamID,
                    ref objProfileBasicViewEntity,
                    ref objLoggedIn
                    );
            objProfileCore = null;
            return this.Json(objProfileBasicViewEntity, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getHighlightedProfiles()
        {
            string strGender = "admin"; // Mugurtham admin, Sangam admin, public user
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            if (objLoggedIn.roleID == "F62DDFBE55448E3A3") // User Profiles 
            {
                if (!string.IsNullOrWhiteSpace(objLoggedIn.BasicInfoCoreEntity.Gender))
                {
                    if (objLoggedIn.BasicInfoCoreEntity.Gender.ToLower().Trim() == "male".ToLower().Trim())
                        strGender = "female";
                    else
                        strGender = "male";
                }
            }
            ProfileCore objProfileCore = new ProfileCore();
            ProfileBasicViewEntity objProfileBasicViewEntity = new ProfileBasicViewEntity();
            using (objProfileCore as IDisposable)
            {
                objProfileCore.GetHighlightedProfiles(Utility.connectionString(),strGender,
                    objLoggedIn.sangamID,
                    ref objProfileBasicViewEntity,
                    ref objLoggedIn
                    );
            }
            objProfileCore = null;
            return this.Json(objProfileBasicViewEntity, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getViewedProfiles()
        {
            string strGender = "admin"; // Mugurtham admin, Sangam admin, public user
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            if (objLoggedIn.roleID == "F62DDFBE55448E3A3") // User Profiles 
            {
                if (!string.IsNullOrWhiteSpace(objLoggedIn.BasicInfoCoreEntity.Gender))
                {
                    if (objLoggedIn.BasicInfoCoreEntity.Gender.ToLower().Trim() == "male".ToLower().Trim())
                        strGender = "female";
                    else
                        strGender = "male";
                }
            }
            ProfileCore objProfileCore = new ProfileCore();
            ProfileBasicViewEntity objProfileBasicViewEntity = new ProfileBasicViewEntity();
            using (objProfileCore as IDisposable)
            {
                objProfileCore.GetViewedProfiles(Utility.connectionString(), strGender,
                    objLoggedIn.LoginID, objLoggedIn.sangamID,
                    ref objProfileBasicViewEntity,
                    ref objLoggedIn
                    );
            }
            objProfileCore = null;
            return this.Json(objProfileBasicViewEntity, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getProfilePhotos()
        {
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            List<Mugurtham.Core.Profile.Photo.PhotoCoreEntity> objPhotoCoreEntityList = new List<Mugurtham.Core.Profile.Photo.PhotoCoreEntity>();
            ProfileCore objProfileCore = new ProfileCore();
            using (objProfileCore as IDisposable)
                objProfileCore.GetProfilePhotos(ref objPhotoCoreEntityList, objLoggedIn.LoginID);
            objProfileCore = null;
            return this.Json(objPhotoCoreEntityList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getAllProfilesBySangam()
        {
            string strGender = "admin"; // Mugurtham admin, Sangam admin, public user
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            if (objLoggedIn.roleID == "F62DDFBE55448E3A3") // User Profiles 
            {
                if (!string.IsNullOrWhiteSpace(objLoggedIn.BasicInfoCoreEntity.Gender))
                {
                    if (objLoggedIn.BasicInfoCoreEntity.Gender.ToLower().Trim() == "male".ToLower().Trim())
                        strGender = "female";
                    else
                        strGender = "male";
                }
            }
            //string cs = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringName"].ConnectionString;
            ProfileBasicViewEntity objProfileBasicViewEntity = new ProfileBasicViewEntity();
            PorfileBasicInfoViewCore objPorfileBasicInfoViewCore = new PorfileBasicInfoViewCore();
            using (objPorfileBasicInfoViewCore as IDisposable)
            {
                objPorfileBasicInfoViewCore.GetAllProfilesBySangam(Utility.connectionString(), strGender,
                    ref objProfileBasicViewEntity,
                    ref objLoggedIn
                    );
            }
            objPorfileBasicInfoViewCore = null;
            //Uncommented the below code for performance optimization - Apr 11 2016 - Anand J
            /*
            List<ProfileCore> objProfileCoreList = new List<ProfileCore>();
            ProfileCore objProfileCore = new ProfileCore();
            using (objProfileCore as IDisposable)
                objProfileCore.GetAll(ref objProfileCoreList, strGender, objLoggedIn.sangamID);
            objProfileCore = null;*/
            //Response.AddHeader("Content-Encoding", "gzip");
            return this.Json(objProfileBasicViewEntity, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult getTestData()
        {
            return this.Json("[{'name':'1','name2':'2'}]", JsonRequestBehavior.AllowGet);
        }
    }
}

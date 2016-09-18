using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mugurtham.Core.ProfileViewed;
using Mugurtham.Core.ProfileInterested;
using Mugurtham.Core.Profile.API;
using System.Data.SqlClient;
using System.Data;
using Mugurtham.Core.Profile.View;
using Mugurtham.Common.Utilities;
using Mugurtham.Service.App_Code.Utility;
using Mugurtham.Service.Controllers;

namespace Mugurtham.Service.Areas.User.Controllers.MVC
{
    [MugurthamAuthorizeAttribute(Mugurtham.Core.Constants.RoleIDForSangamAdmin,
                             Mugurtham.Core.Constants.RoleIDForUserProfile,
                             Mugurtham.Core.Constants.RoleIDForMugurthamAdmin)]
    public class UserController : MugurthamBaseController
    {
        //
        // GET: /User/User/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }
        public ActionResult UserSettingsForm()
        {
            return View();
        }
        public ActionResult RecentlyJoined()
        {
            return View();
        }
        public ActionResult HighlightedProfiles()
        {
            return View();
        }
        public ActionResult ViewedProfiles()
        {
            return View();
        }
        public ActionResult InterestedProfiles()
        {
            return View();
        }
        public ActionResult InterestedInMeProfiles()
        {
            return View();
        }
        public ActionResult Add(string ID)
        {
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            string strUserID = string.Empty;
            ProfileViewedCore objProfileViewedCore = new ProfileViewedCore();
            using (objProfileViewedCore as IDisposable)
            {
                ProfileViewedCoreEntity objProfileViewedCoreEntity = new ProfileViewedCoreEntity();
                using (objProfileViewedCoreEntity as IDisposable)
                {
                    objProfileViewedCoreEntity.ViewerID = objLoggedIn.LoginID;
                    objProfileViewedCoreEntity.ViewedID = ID;
                    objProfileViewedCore.Add(ref objProfileViewedCoreEntity);
                }
                objProfileViewedCoreEntity = null;
            }
            objProfileViewedCore = null;
            return this.Json("Success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult ShowInterest(string ID)
        {
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            string strUserID = string.Empty;
            ProfileInterestedCore objProfileInterestedCore = new ProfileInterestedCore();
            using (objProfileInterestedCore as IDisposable)
            {
                ProfileInterestedCoreEntity objProfileInterestedCoreEntity = new ProfileInterestedCoreEntity();
                using (objProfileInterestedCoreEntity as IDisposable)
                {
                    objProfileInterestedCoreEntity.ViewerID = objLoggedIn.LoginID;
                    objProfileInterestedCoreEntity.InterestedInID = ID;
                    objProfileInterestedCore.Add(ref objProfileInterestedCoreEntity);
                }
                objProfileInterestedCoreEntity = null;
            }
            objProfileInterestedCore = null;
            return this.Json("Success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult RemoveInterest(string ID)
        {
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            string strUserID = string.Empty;
            ProfileInterestedCore objProfileInterestedCore = new ProfileInterestedCore();
            using (objProfileInterestedCore as IDisposable)
            {
                ProfileInterestedCoreEntity objProfileInterestedCoreEntity = new ProfileInterestedCoreEntity();
                using (objProfileInterestedCoreEntity as IDisposable)
                    objProfileInterestedCore.Delete(objLoggedIn.LoginID, ID);
                objProfileInterestedCoreEntity = null;
            }
            objProfileInterestedCore = null;
            return this.Json("Success", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult getInterestedProfiles()
        {
            string strGender = "admin"; // Mugurtham admin, Sangam admin, public user
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            if (objLoggedIn.roleID == Mugurtham.Core.Constants.RoleIDForUserProfile) // User Profiles 
            {
                if (!string.IsNullOrWhiteSpace(objLoggedIn.BasicInfoCoreEntity.Gender))
                {
                    if (objLoggedIn.BasicInfoCoreEntity.Gender.ToLower().Trim() == "male".ToLower().Trim())
                        strGender = "female";
                    else
                        strGender = "male";
                }
            }
            ProfileBasicViewEntity objProfileBasicViewEntity = new ProfileBasicViewEntity();
            ProfileInterestedCore objProfileInterestedCore = new ProfileInterestedCore();
            using (objProfileInterestedCore as IDisposable)
            {
                objProfileInterestedCore.GetInterestedProfiles(Utility.connectionString(), strGender,
                    objLoggedIn.LoginID, objLoggedIn.sangamID,
                    ref objProfileBasicViewEntity,
                    ref objLoggedIn
                    );
            }
            objProfileInterestedCore = null;
            return this.Json(objProfileBasicViewEntity, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getInterestedInMeProfiles()
        {
            string strGender = "admin"; // Mugurtham admin, Sangam admin, public user
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            if (objLoggedIn.roleID == Mugurtham.Core.Constants.RoleIDForUserProfile) // User Profiles 
            {
                if (!string.IsNullOrWhiteSpace(objLoggedIn.BasicInfoCoreEntity.Gender))
                {
                    if (objLoggedIn.BasicInfoCoreEntity.Gender.ToLower().Trim() == "male".ToLower().Trim())
                        strGender = "female";
                    else
                        strGender = "male";
                }
            }
            ProfileBasicViewEntity objProfileBasicViewEntity = new ProfileBasicViewEntity();
            ProfileInterestedCore objProfileInterestedCore = new ProfileInterestedCore();
            using (objProfileInterestedCore as IDisposable)
            {
                objProfileInterestedCore.GetInterestedInMeProfiles(Utility.connectionString(), strGender,
                    objLoggedIn.LoginID, objLoggedIn.sangamID,
                    ref objProfileBasicViewEntity,
                    ref objLoggedIn
                    );
            }
            objProfileInterestedCore = null;
            return this.Json(objProfileBasicViewEntity, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getUserBadgeCount()
        {
            string strGender = "admin"; // Mugurtham admin, Sangam admin, public user
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            if (objLoggedIn.roleID == Mugurtham.Core.Constants.RoleIDForUserProfile) // User Profiles 
            {
                if (!string.IsNullOrWhiteSpace(objLoggedIn.BasicInfoCoreEntity.Gender))
                {
                    if (objLoggedIn.BasicInfoCoreEntity.Gender.ToLower().Trim() == "male".ToLower().Trim())
                        strGender = "female";
                    else
                        strGender = "male";
                }
            }
            UserBadgeCount objUserBadgeCount = new UserBadgeCount();
            objUserBadgeCount.InterestedInMeProfiles = 0;
            objUserBadgeCount.InterestedProfiles = 0;
            objUserBadgeCount.ViewedProfiles = 0;
            objUserBadgeCount.HighlightedProfiles = 0;
            objUserBadgeCount.RecentlyJoined = 0;
            using (SqlConnection objSqlConnection = new SqlConnection(Utility.connectionString()))
            {
                objSqlConnection.Open();
                // 1.  create a command object identifying the stored procedure
                SqlCommand objSqlCommand = new SqlCommand("uspGetProfileBadgeCount", objSqlConnection);

                // 2. set the command object so it knows to execute a stored procedure
                objSqlCommand.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                objSqlCommand.Parameters.Add(new SqlParameter("@GENDER", strGender));
                objSqlCommand.Parameters.Add(new SqlParameter("@INTERESTEDID", objLoggedIn.LoginID));
                objSqlCommand.Parameters.Add(new SqlParameter("@SANGAMID", objLoggedIn.sangamID));

                // execute the command
                using (SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader())
                {
                    while (objSqlDataReader.Read())
                    {
                        if (objSqlDataReader["HighlightedProfilesCount"] != null)
                            objUserBadgeCount.HighlightedProfiles = Convert.ToInt32(objSqlDataReader["HighlightedProfilesCount"].ToString());
                        if (objSqlDataReader["InterestedInMeProfilesCount"] != null)
                            objUserBadgeCount.InterestedInMeProfiles = Convert.ToInt32(objSqlDataReader["InterestedInMeProfilesCount"].ToString());
                        if (objSqlDataReader["InterestedProfilesCount"] != null)
                            objUserBadgeCount.InterestedProfiles = Convert.ToInt32(objSqlDataReader["InterestedProfilesCount"].ToString());
                        if (objSqlDataReader["ProfilesJoinedThisWeekCount"] != null)
                            objUserBadgeCount.RecentlyJoined = Convert.ToInt32(objSqlDataReader["ProfilesJoinedThisWeekCount"].ToString());
                        if (objSqlDataReader["ProfilesViewedMeCount"] != null)
                            objUserBadgeCount.ViewedProfiles = Convert.ToInt32(objSqlDataReader["ProfilesViewedMeCount"].ToString());
                    }
                    objSqlDataReader.Close();
                }
                objSqlCommand.Cancel();
                objSqlCommand.Dispose();
                objSqlConnection.Close();
                objSqlConnection.Dispose();
            }

            /*
            List<ProfileCore> objProfileCoreList = new List<ProfileCore>();
            ProfileInterestedCore objProfileInterestedCore = new ProfileInterestedCore();
            using (objProfileInterestedCore as IDisposable)
                objProfileInterestedCore.GetInterestedInMeProfiles(ref objProfileCoreList, strGender, objLoggedIn.LoginID, objLoggedIn.sangamID);
            if (objProfileCoreList != null)
                objUserBadgeCount.InterestedInMeProfiles = objProfileCoreList.Count;
            objProfileCoreList = null;
            List<ProfileCore> objIntProfProfileCoreList = new List<ProfileCore>();
            objProfileInterestedCore.GetInterestedProfiles(ref objIntProfProfileCoreList, strGender, objLoggedIn.LoginID, objLoggedIn.sangamID);
            objProfileInterestedCore = null;
            if (objIntProfProfileCoreList != null)
                objUserBadgeCount.InterestedProfiles = objIntProfProfileCoreList.Count;
            objIntProfProfileCoreList = null;
            ProfileCore objProfileCore = new ProfileCore();
            using (objProfileCore as IDisposable)
            {
                List<ProfileCore> objViewedProfileCoreList = new List<ProfileCore>();
                objProfileCore.GetViewedProfiles(ref objViewedProfileCoreList, strGender, objLoggedIn.LoginID, objLoggedIn.sangamID);
                if (objViewedProfileCoreList != null)
                    objUserBadgeCount.ViewedProfiles = objViewedProfileCoreList.Count;
                objViewedProfileCoreList = null;
                List<ProfileCore> objHighlightedProfileCoreList = new List<ProfileCore>();
                objProfileCore.GetHighlightedProfiles(ref objHighlightedProfileCoreList, strGender, objLoggedIn.sangamID);
                if (objHighlightedProfileCoreList != null)
                    objUserBadgeCount.HighlightedProfiles = objHighlightedProfileCoreList.Count;
                objHighlightedProfileCoreList = null;
                List<ProfileCore> objRecentlyProfileCoreList = new List<ProfileCore>();
                objProfileCore.GetRecentlyJoined(ref objRecentlyProfileCoreList, strGender, objLoggedIn.sangamID);
                if (objRecentlyProfileCoreList != null)
                    objUserBadgeCount.RecentlyJoined = objRecentlyProfileCoreList.Count;
                objRecentlyProfileCoreList = null;
            }
            objProfileCore = null;
            */
            return this.Json(objUserBadgeCount, JsonRequestBehavior.AllowGet);
        }
    }

    public class UserBadgeCount
    {
        public int InterestedInMeProfiles { get; set; }
        public int InterestedProfiles { get; set; }
        public int ViewedProfiles { get; set; }
        public int HighlightedProfiles { get; set; }
        public int RecentlyJoined { get; set; }
    }
}

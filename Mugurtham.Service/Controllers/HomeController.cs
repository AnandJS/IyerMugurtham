using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Mugurtham.Common.Utilities;
using Mugurtham.Core.Login;
using System.IO;
using Mugurtham.Core.Profile.API;
using Mugurtham.Core.Dashboard.Sangam;
using System.Text;

namespace Mugurtham.Service.Controllers
{
    [AllowAnonymous]
    public class HomeController : MugurthamBaseController
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        public ActionResult HttpError404()
        {
            return View();
        }

        public ActionResult HttpError500()
        {
            return View();
        }

        public ActionResult General()
        {
            return View();
        }

        public void downloadLogFile()
        {
            string strLogText = Helpers.readLogFile(Mugurtham.Service.App_Code.Utility.Utility.logFilePath());
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("Content-Length", strLogText.Length.ToString());
            Response.ContentType = "text/plain";
            Response.AppendHeader("content-disposition", "attachment;filename=\"MugurthamLog.log\"");
            Response.Write(strLogText);
            Response.End();
        }

        [HttpPost]
        public ActionResult SaveFile(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View("UploadFile");
        }
        [HttpPost]
        public ActionResult validateLogin([System.Web.Http.FromBody]Mugurtham.Core.User.UserCoreEntity objUserCoreEntity)
        {
            int inLoginStatus = 0;
            bool boolLogin = false;

            Mugurtham.Core.User.UserCore objUserCore = new Mugurtham.Core.User.UserCore();
            using (objUserCore as IDisposable)
            {
                inLoginStatus = objUserCore.validateLogin(ref objUserCoreEntity, out boolLogin);
                if (inLoginStatus == 1)
                {
                    objUserCore.createSession(Helpers.primaryKey, objUserCoreEntity.LoginID,
                                              Request.ServerVariables["REMOTE_ADDR"].ToString());
                    FormsAuthentication.SetAuthCookie(objUserCoreEntity.LoginID, false);
                    Session.Timeout = 60;
                }
            }
            objUserCore = null; LoggedInUser objLoggedIn = new LoggedInUser(objUserCoreEntity.LoginID);
            Session["LoggedInUser"] = objLoggedIn;
            return this.Json(objUserCoreEntity);
        }
        [HttpGet]
        public ActionResult getSangamDashBoardChart()
        {
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            List<Mugurtham.Core.Dashboard.Sangam.SangamDashboardCoreEntity> objListSangamDashboardCoreEntity = new List<Core.Dashboard.Sangam.SangamDashboardCoreEntity>();
            SangamDashboardCore objSangamDashboardCore = new SangamDashboardCore();
            using (objSangamDashboardCore as IDisposable)
                objListSangamDashboardCoreEntity = objSangamDashboardCore.GetAll(objLoggedIn.sangamID);
            objSangamDashboardCore = null;
            return this.Json(objListSangamDashboardCoreEntity, JsonRequestBehavior.AllowGet);
        }
    }
}

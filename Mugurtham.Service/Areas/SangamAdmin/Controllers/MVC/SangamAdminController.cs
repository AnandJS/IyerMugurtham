using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mugurtham.Service.Controllers;
using System.IO;
using Mugurtham.Common.Utilities;

namespace Mugurtham.Service.Areas.SangamAdmin.Controllers.MVC
{
    [MugurthamAuthorizeAttribute(Mugurtham.Core.Constants.RoleIDForSangamAdmin)]
    public class SangamAdminController :  MugurthamBaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Settings()
        {
            return View();
        }
        public ActionResult SangamAdminProfiles()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveSangamLogo(HttpPostedFileBase file)
        {
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images/Mugurtham/Sangam/Logo"),
                                              objLoggedIn.sangamID + Path.GetExtension(Path.GetFileName(file.FileName)));
                    file.SaveAs(path);
                    Mugurtham.Core.Sangam.SangamCore objSangamCore = new Core.Sangam.SangamCore();
                    using (objSangamCore as IDisposable)
                    {
                        Mugurtham.Core.Sangam.SangamCoreEntity objSangamCoreEntity = new Core.Sangam.SangamCoreEntity();
                        using (objSangamCoreEntity as IDisposable)
                        {
                            objSangamCoreEntity = objSangamCore.GetByID(objLoggedIn.sangamID);
                            objSangamCoreEntity.LogoPath = "/Images/Mugurtham/Sangam/Logo/" + objLoggedIn.sangamID + Path.GetExtension(Path.GetFileName(file.FileName));
                            objSangamCore.Edit(ref objSangamCoreEntity);
                        }
                        objSangamCoreEntity = null;
                    }
                    objSangamCore = null;
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return Redirect("/Mugurtham#/SangamAdminSettings");
        }

        [HttpPost]
        public ActionResult SaveSangamBanner(HttpPostedFileBase file)
        {
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images/Mugurtham/Sangam/Banner"),
                                               objLoggedIn.sangamID + Path.GetExtension(Path.GetFileName(file.FileName)));
                    file.SaveAs(path);
                    Mugurtham.Core.Sangam.SangamCore objSangamCore = new Core.Sangam.SangamCore();
                    using (objSangamCore as IDisposable)
                    {
                        Mugurtham.Core.Sangam.SangamCoreEntity objSangamCoreEntity = new Core.Sangam.SangamCoreEntity();
                        using(objSangamCoreEntity as IDisposable)
                        {
                            objSangamCoreEntity = objSangamCore.GetByID(objLoggedIn.sangamID);
                            objSangamCoreEntity.BannerPath = "/Images/Mugurtham/Sangam/Banner/" + objLoggedIn.sangamID + Path.GetExtension(Path.GetFileName(file.FileName));
                            objSangamCore.Edit(ref objSangamCoreEntity);
                        }
                        objSangamCoreEntity = null;
                    }
                    objSangamCore = null;
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return Redirect("/Mugurtham#/SangamAdminSettings");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mugurtham.Service.Controllers;
using Mugurtham.Common.Utilities;
using Mugurtham.Core.Profile.Photo;


namespace Mugurtham.Service.Areas.Profile.Controllers.MVC
{
    [MugurthamAuthorizeAttribute(Mugurtham.Core.Constants.RoleIDForSangamAdmin, 
                                 Mugurtham.Core.Constants.RoleIDForUserProfile, 
                                 Mugurtham.Core.Constants.RoleIDForMugurthamAdmin)]
    public class ProfileController : MugurthamBaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BasicInfo()
        {
            return View();
        }
        public ActionResult Career()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Family()
        {
            return View();
        }
        public ActionResult Location()
        {
            return View();
        }
        public ActionResult Reference()
        {
            return View();
        }
        public ActionResult Horoscope()
        {
            return View();
        }
        public ActionResult Photo()
        {
            return View();
        }
        public ActionResult Album()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveProfilePhoto(HttpPostedFileBase file, string ProfileID)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];                    
                    Mugurtham.Core.BasicInfo.BasicInfoCore objBasicInfoCore = new Core.BasicInfo.BasicInfoCore();
                    using (objBasicInfoCore as IDisposable)
                    {
                        Mugurtham.Core.BasicInfo.BasicInfoCoreEntity objBasicInfoCoreEntity = new Core.BasicInfo.BasicInfoCoreEntity();
                        using (objBasicInfoCoreEntity as IDisposable)
                        {
                            objBasicInfoCoreEntity = objBasicInfoCore.GetByProfileID(ProfileID);
                            objBasicInfoCoreEntity.PhotoPath = "/Areas/Profile/Images/ProfilePhoto/" + ProfileID + Path.GetExtension(Path.GetFileName(file.FileName));
                            string strFilePath = Path.Combine(Server.MapPath("~/Areas/Profile/Images/ProfilePhoto"),
                                              ProfileID + Path.GetExtension(Path.GetFileName(file.FileName)));
                            file.SaveAs(strFilePath);
                            objBasicInfoCore.Edit(ref objBasicInfoCoreEntity);
                        }
                        objBasicInfoCoreEntity = null;
                    }
                    objBasicInfoCore = null;
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return Redirect("/Mugurtham#/Photo");
        }
        [HttpPost]
        public ActionResult Add([System.Web.Http.FromBody]Mugurtham.Core.BasicInfo.BasicInfoCoreEntity objBasicInfoCoreEntity)
        {
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            string strProfileID = string.Empty;
            Mugurtham.Core.Profile.API.ProfileCore objProfileCore = new Mugurtham.Core.Profile.API.ProfileCore();
            using (objProfileCore as IDisposable)
            {
                objProfileCore.Add(ref objBasicInfoCoreEntity, out strProfileID, objLoggedIn);
            }
            objProfileCore = null;
            return this.Json(strProfileID, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult SaveProfilePhotoAlbum(List<HttpPostedFileBase> file, string ProfileID)
        {
            string strFileName = string.Empty;
            string strProfilePhotoPath = string.Empty;
            int intProfilePhotoIndex = 1;
            // Create if profile directory does not exsist
            string strProfileFolderPath = Path.Combine(Server.MapPath("~/Areas/Profile/Images/ProfilePhoto/" + ProfileID));
            if (!Directory.Exists(strProfileFolderPath))
                Directory.CreateDirectory(strProfileFolderPath);
            foreach (HttpPostedFileBase item in file)
            {
                if (item != null)
                {
                    strFileName = Helpers.primaryKey;
                    strProfilePhotoPath = "/Areas/Profile/Images/ProfilePhoto/" + ProfileID + "/" + strFileName + Path.GetExtension(Path.GetFileName(item.FileName));
                }
                //if (Array.Exists(model.FilesToBeUploaded.Split(','), s => s.Equals(item.FileName)))                
                if (
                    Path.GetExtension(Path.GetFileName(item.FileName)).ToString().ToLower() == ".jpg".ToString().ToLower() ||
                    Path.GetExtension(Path.GetFileName(item.FileName)).ToString().ToLower() == ".jpeg".ToString().ToLower() ||
                    Path.GetExtension(Path.GetFileName(item.FileName)).ToString().ToLower() == ".gif".ToString().ToLower() ||
                    Path.GetExtension(Path.GetFileName(item.FileName)).ToString().ToLower() == ".png".ToString().ToLower()
                    )
                {
                    try
                    {
                        Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
                        Mugurtham.Core.BasicInfo.BasicInfoCore objBasicInfoCore = new Core.BasicInfo.BasicInfoCore();
                        using (objBasicInfoCore as IDisposable)
                        {
                            Mugurtham.Core.BasicInfo.BasicInfoCoreEntity objBasicInfoCoreEntity = new Core.BasicInfo.BasicInfoCoreEntity();
                            using (objBasicInfoCoreEntity as IDisposable)
                            {
                                objBasicInfoCoreEntity = objBasicInfoCore.GetByProfileID(ProfileID);
                                objBasicInfoCoreEntity.PhotoPath = strProfilePhotoPath;
                                string strFilePath = Path.Combine(Server.MapPath("~/Areas/Profile/Images/ProfilePhoto/" + ProfileID),
                                                  strFileName + Path.GetExtension(Path.GetFileName(item.FileName)));
                                item.SaveAs(strFilePath);
                                savePhotoToFolder(strProfilePhotoPath, ProfileID);
                                if (intProfilePhotoIndex == 1)
                                    objBasicInfoCore.Edit(ref objBasicInfoCoreEntity);
                            }
                            objBasicInfoCoreEntity = null;
                        }
                        objBasicInfoCore = null;
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }
                intProfilePhotoIndex += 1;
            }
            return Redirect("/Mugurtham#/Photo");
        }
        private int savePhotoToFolder(string strPhotoPath, string strProfileID)
        {
            Mugurtham.Core.Profile.Photo.PhotoCore objPhotoCore = new Core.Profile.Photo.PhotoCore();
            using (objPhotoCore as IDisposable)
            {
                Mugurtham.Core.Profile.Photo.PhotoCoreEntity objPhotoCoreEntity = new Core.Profile.Photo.PhotoCoreEntity();
                using (objPhotoCoreEntity as IDisposable)
                {
                    objPhotoCoreEntity.IsProfilePic = 0;
                    objPhotoCoreEntity.PhotoPath = strPhotoPath;
                    objPhotoCoreEntity.ProfileID = strProfileID;
                    objPhotoCore.Add(ref objPhotoCoreEntity);
                }
                objPhotoCoreEntity = null;
            }
            objPhotoCore = null;
            return 0;
        }
        public ActionResult RemoveProfilePic(string ID)
        {
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = (Mugurtham.Core.Login.LoggedInUser)Session["LoggedInUser"];
            string strUserID = string.Empty;
            PhotoCore objPhotoCore = new PhotoCore();
            using (objPhotoCore as IDisposable)
                objPhotoCore.Delete(ID);
            objPhotoCore = null;           
            return this.Json("Success", JsonRequestBehavior.AllowGet);
        }

    }
}

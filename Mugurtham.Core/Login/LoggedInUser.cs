using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.Common.Utilities;

namespace Mugurtham.Core.Login
{
    public class LoggedInUser : IDisposable
    {
        private static readonly object padlock = new object();
        private Core.User.UserCoreEntity objUserCoreEntity = null;
        private Core.Sangam.SangamCoreEntity objSangamCoreEntity = null;
        private Core.BasicInfo.BasicInfoCoreEntity objBasicInfoCoreEntity = null;
        string _strLoggedInID = string.Empty;

        public LoggedInUser(string strLoggedInID)
        {
            _strLoggedInID = strLoggedInID;
            initializeUser();
        }

        private int initializeUser()
        {
            try
            {
                Core.User.UserCore objUserCore = new Core.User.UserCore();
                using (objUserCore as IDisposable)
                {
                    objUserCoreEntity = objUserCore.GetByLoginID(_strLoggedInID);
                }
                objUserCore = null;
                Core.BasicInfo.BasicInfoCore objBasicInfoCore = new BasicInfo.BasicInfoCore();
                using (objBasicInfoCore as IDisposable)
                    objBasicInfoCoreEntity = objBasicInfoCore.GetByProfileID(_strLoggedInID);
                objBasicInfoCore = null;
                if (objUserCoreEntity.SangamID != null)
                {
                    Core.Sangam.SangamCore objSangamCore = new Sangam.SangamCore();
                    using (objSangamCore as IDisposable)
                    {
                        objSangamCoreEntity = objSangamCore.GetByID(objUserCoreEntity.SangamID);
                    }
                    objSangamCore = null;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        public string ID
        {
            get
            {
                return objUserCoreEntity.ID;
            }
        }
        public string LoginID
        {
            get
            {
                return objUserCoreEntity.LoginID;
            }
        }
        public string Name
        {
            get
            {
                return objUserCoreEntity.Name;
            }
        }
        public string sangamID
        {
            get
            {
                return objUserCoreEntity.SangamID;
            }
        }
        public string roleID
        {
            get
            {
                return objUserCoreEntity.RoleID;
            }
        }
        public string themeID
        {
            get
            {
                return objUserCoreEntity.ThemeID;
            }
        }
        public string localeID
        {
            get
            {
                return objUserCoreEntity.LocaleID;
            }
        }
        public string IsActivated
        {
            get
            {
                return objUserCoreEntity.IsActivated;
            }
        }
        public string HomePagePath
        {
            get
            {
                return objUserCoreEntity.HomePagePath;
            }
        }
        public string SangamName
        {
            get
            {
                return objSangamCoreEntity.Name;
            }
        }
        public string AboutSangam
        {
            get
            {
                return objSangamCoreEntity.AboutSangam;
            }
        }
        public string SangamAddress
        {
            get
            {
                return objSangamCoreEntity.Address;
            }
        }
        public string SangamContactNumber
        {
            get
            {
                return objSangamCoreEntity.ContactNumber;
            }
        }
        public string SangamIsActivate
        {
            get
            {
                return objSangamCoreEntity.IsActivated;
            }
        }
        public string SangamProfileIDStartsWith
        {
            get
            {
                return objSangamCoreEntity.ProfileIDStartsWith;
            }
        }
        public string SangamLogoPath
        {
            get
            {
                return objSangamCoreEntity.LogoPath;
            }
        }
        public string SangamBannerPath
        {
            get
            {
                return objSangamCoreEntity.BannerPath;
            }
        }
        public Core.BasicInfo.BasicInfoCoreEntity BasicInfoCoreEntity
        {
            get
            {
                return objBasicInfoCoreEntity;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }
        }
    }
}

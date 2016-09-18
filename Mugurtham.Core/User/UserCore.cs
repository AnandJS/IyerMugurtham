using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.UOW;
using Mugurtham.Common.Utilities;
using System.Data.SqlClient;
using System.Data;

namespace Mugurtham.Core.User
{
    public class UserCore
    {
        public int Add(ref Mugurtham.Core.User.UserCoreEntity objUserCoreEntity, out string strUserID)
        {
            strUserID = Helpers.primaryKey;
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.User.User objDTOUser = new DTO.User.User();
                    using (objDTOUser as IDisposable)
                    {
                        objUserCoreEntity.ID = strUserID;
                        assignHomePagePath(ref objUserCoreEntity);
                        AssignDTOFromEntity(ref objDTOUser, ref objUserCoreEntity);
                    }
                    objIUnitOfWork.RepositoryUser.Add(objDTOUser);
                    objDTOUser = null;
                }
                objIUnitOfWork.commit();
                objIUnitOfWork = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        public int Edit(ref Mugurtham.Core.User.UserCoreEntity objUserCoreEntity)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.User.User objDTOUser = new DTO.User.User();
                    using (objDTOUser as IDisposable)
                    {
                        assignHomePagePath(ref objUserCoreEntity);
                        AssignDTOFromEntity(ref objDTOUser, ref objUserCoreEntity);
                    }
                    objIUnitOfWork.RepositoryUser.Edit(objDTOUser);
                    objDTOUser = null;
                }
                objIUnitOfWork.commit();
                objIUnitOfWork = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        public UserCoreEntity GetByID(string strID)
        {
            UserCoreEntity objUserCoreEntity = new UserCoreEntity();
            try
            {
                Mugurtham.DTO.User.User objUser = new Mugurtham.DTO.User.User();
                IUnitOfWork objUOW = new UnitOfWork();
                using (objUOW as IDisposable)
                    objUser = objUOW.RepositoryUser.GetAll().ToList().Where(p => p.ID.Trim().ToLower() == strID.Trim().ToLower()).FirstOrDefault();
                objUOW = null;
                if (objUser != null)
                {
                    using (objUser as IDisposable)
                    {
                        AssignEntityFromDTO(ref objUser, ref objUserCoreEntity);
                    }
                }
                objUser = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return objUserCoreEntity;
        }
        public UserCoreEntity GetByLoginID(string strID)
        {
            UserCoreEntity objUserCoreEntity = new UserCoreEntity();
            try
            {
                Mugurtham.DTO.User.User objSangam = new Mugurtham.DTO.User.User();
                IUnitOfWork objUOW = new UnitOfWork();
                using (objUOW as IDisposable)
                    objSangam = objUOW.RepositoryUser.GetAll().ToList().Where(p => p.LoginID.Trim().ToLower() == strID.Trim().ToLower()).FirstOrDefault();
                objUOW = null;
                if (objSangam != null)
                {
                    using (objSangam as IDisposable)
                    {
                        AssignEntityFromDTO(ref objSangam, ref objUserCoreEntity);
                    }
                }
                objSangam = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return objUserCoreEntity;
        }
        public int GetAll(ref List<UserCoreEntity> objUserCoreEntityList)
        {
            IUnitOfWork objIUnitOfWork = new UnitOfWork();
            try
            {
                using (objIUnitOfWork as IDisposable)
                {
                    foreach (Mugurtham.DTO.User.User objSangam in objIUnitOfWork.RepositoryUser.GetAll().ToList())
                    {
                        Mugurtham.DTO.User.User _objSangam = objSangam;
                        using (_objSangam as IDisposable)
                        {
                            UserCoreEntity objUserCoreEntity = new UserCoreEntity();
                            using (objUserCoreEntity as IDisposable)
                            {
                                AssignEntityFromDTO(ref _objSangam, ref objUserCoreEntity);
                                Sangam.SangamCore objSangamCore = new Sangam.SangamCore();
                                using (objSangamCore as IDisposable)
                                {
                                    Sangam.SangamCoreEntity objSangamCoreEntity = new Sangam.SangamCoreEntity();
                                    using (objSangamCoreEntity as IDisposable)
                                    {
                                        objSangamCoreEntity = objSangamCore.GetByID(objUserCoreEntity.SangamID);
                                        objUserCoreEntity.SangamName = objSangamCoreEntity.Name;
                                    }
                                    objSangamCoreEntity = null;
                                }
                                objSangamCore = null;
                                objUserCoreEntityList.Add(objUserCoreEntity);
                            }
                            objUserCoreEntity = null;
                        }
                        _objSangam = null;
                    }
                }
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        public int GetAllSangamUsers(ref List<UserCoreEntity> objUserCoreEntityList, string strSangamID)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    foreach (Mugurtham.DTO.User.User objSangam in objIUnitOfWork.RepositoryUser.GetAll().Where(p => p.SangamID == strSangamID).ToList())
                    {
                        Mugurtham.DTO.User.User _objSangam = objSangam;
                        using (_objSangam as IDisposable)
                        {
                            UserCoreEntity objUserCoreEntity = new UserCoreEntity();
                            using (objUserCoreEntity as IDisposable)
                            {
                                AssignEntityFromDTO(ref _objSangam, ref objUserCoreEntity);
                                Sangam.SangamCore objSangamCore = new Sangam.SangamCore();
                                using (objSangamCore as IDisposable)
                                {
                                    Sangam.SangamCoreEntity objSangamCoreEntity = new Sangam.SangamCoreEntity();
                                    using (objSangamCoreEntity as IDisposable)
                                    {
                                        objSangamCoreEntity = objSangamCore.GetByID(objUserCoreEntity.SangamID);
                                        objUserCoreEntity.SangamName = objSangamCoreEntity.Name;
                                    }
                                    objSangamCoreEntity = null;
                                }
                                objSangamCore = null;
                                objUserCoreEntityList.Add(objUserCoreEntity);
                            }
                            objUserCoreEntity = null;
                        }
                        _objSangam = null;
                    }
                }
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        private int AssignDTOFromEntity(ref Mugurtham.DTO.User.User objDTOUser, ref Mugurtham.Core.User.UserCoreEntity objUserCoreEntity)
        {
            try
            {
                objDTOUser.CreatedBy = objUserCoreEntity.CreatedBy;
                objDTOUser.CreatedDate = DateTime.Now;
                objDTOUser.ID = objUserCoreEntity.ID;
                objDTOUser.LoginID = objUserCoreEntity.LoginID;
                objDTOUser.Password = Helpers.EncodePasswordToBase64(objUserCoreEntity.Password);
                objDTOUser.IsActivated = objUserCoreEntity.IsActivated;
                objDTOUser.LocaleID = objUserCoreEntity.LocaleID;
                objDTOUser.ModifiedBy = objUserCoreEntity.ModifiedBy;
                objDTOUser.ModifiedDate = DateTime.Now;
                objDTOUser.Name = objUserCoreEntity.Name;
                objDTOUser.RoleID = objUserCoreEntity.RoleID;
                objDTOUser.SangamID = objUserCoreEntity.SangamID;
                objDTOUser.ThemeID = objUserCoreEntity.ThemeID;
                objDTOUser.HomePagePath = objUserCoreEntity.HomePagePath;
                objDTOUser.IsHighlighted = objUserCoreEntity.IsHighlighted;
                objDTOUser.ShowHoroscope = objUserCoreEntity.ShowHoroscope;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        private int AssignEntityFromDTO(ref Mugurtham.DTO.User.User objDTOUser, ref Mugurtham.Core.User.UserCoreEntity objUserCoreEntity)
        {
            try
            {
                objUserCoreEntity.CreatedBy = objDTOUser.CreatedBy;
                objUserCoreEntity.CreatedDate = DateTime.Now;
                objUserCoreEntity.ID = objDTOUser.ID;
                objUserCoreEntity.LoginID = objDTOUser.LoginID;
                objUserCoreEntity.Password = objDTOUser.Password;
                objUserCoreEntity.IsActivated = objDTOUser.IsActivated;
                objUserCoreEntity.LocaleID = objDTOUser.LocaleID;
                objUserCoreEntity.ModifiedBy = objDTOUser.ModifiedBy;
                objUserCoreEntity.ModifiedDate = DateTime.Now;
                objUserCoreEntity.Name = objDTOUser.Name;
                objUserCoreEntity.RoleID = objDTOUser.RoleID;
                objUserCoreEntity.SangamID = objDTOUser.SangamID;
                objUserCoreEntity.ThemeID = objDTOUser.ThemeID;
                objUserCoreEntity.HomePagePath = objDTOUser.HomePagePath;
                objUserCoreEntity.IsHighlighted = objDTOUser.IsHighlighted;
                objUserCoreEntity.ShowHoroscope = objDTOUser.ShowHoroscope;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        /*========================================================================================================*/
        /*BUSINESS FUNCTIONS - APART CRUD*/
        /*========================================================================================================*/
        public int validateLogin(ref Mugurtham.Core.User.UserCoreEntity objUserCoreEntity, out bool boolLogin)
        {
            /*             
             1 -> Success
             2 -> Invalid User
             3 -> Invalid Password
             4 -> DeActivated Sangam
             5 -> DeActivated Profile
             */
            int intLoginStatus = 0;
            boolLogin = false;

            try
            {
                Mugurtham.Core.User.UserCoreEntity _objUserCoreEntity = null;
                _objUserCoreEntity = GetByLoginID(objUserCoreEntity.LoginID);
                if (_objUserCoreEntity.LoginID == null)
                {
                    intLoginStatus = 2;
                    objUserCoreEntity.LoginStatus = "2";
                    return intLoginStatus;
                }
                // Validate if Sangam is activated
                Sangam.SangamCore objSangamCore = new Sangam.SangamCore();
                using (objSangamCore as IDisposable)
                {
                    Sangam.SangamCoreEntity objSangamCoreEntity = new Sangam.SangamCoreEntity();
                    using (objSangamCoreEntity as IDisposable)
                    {
                        objSangamCoreEntity = objSangamCore.GetByID(_objUserCoreEntity.SangamID);
                        if (objSangamCoreEntity.IsActivated == "0")
                        {
                            intLoginStatus = 4;
                            objUserCoreEntity.LoginStatus = "4";
                        }
                    }
                    objSangamCoreEntity = null;
                }
                objSangamCore = null;
                if (intLoginStatus == 4)
                    return intLoginStatus;
                // Validate if User is activated
                if (_objUserCoreEntity.IsActivated == "0")
                {
                    intLoginStatus = 5;
                    objUserCoreEntity.LoginStatus = "5";
                    return intLoginStatus;
                }
                //Validate if loginid and password matches
                if (_objUserCoreEntity.Password.Trim() == Helpers.EncodePasswordToBase64(objUserCoreEntity.Password.Trim()))
                {
                    intLoginStatus = 1;
                    _objUserCoreEntity.LoginStatus = "1";
                    objUserCoreEntity = _objUserCoreEntity;
                    boolLogin = true;
                }
                else
                {
                    intLoginStatus = 3;
                    objUserCoreEntity.LoginStatus = "3";
                }
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return intLoginStatus;
        }
        public int assignHomePagePath(ref UserCoreEntity objUserCoreEntity)
        {
            try
            {
                if (objUserCoreEntity.RoleID == Constants.RoleIDForMugurthamAdmin)
                    objUserCoreEntity.HomePagePath = Constants.HomePagePathForMugurthamAdmin;
                else if (objUserCoreEntity.RoleID == Constants.RoleIDForSangamAdmin)
                    objUserCoreEntity.HomePagePath = Constants.HomePagePathForSangamAdmin;
                else if (objUserCoreEntity.RoleID == Constants.RoleIDForUserProfile)
                    objUserCoreEntity.HomePagePath = Constants.HomePagePathForProfileUser;
                else if (objUserCoreEntity.RoleID == Constants.RoleIDForUserPublic)
                    objUserCoreEntity.HomePagePath = Constants.HomePagePathForPublicUser;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }

        /// <summary>
        /// Creates a new session when logged in
        /// This implementation has to be swapped to EF logic and not in ADO.Net 
        /// Changes it asap.
        /// </summary>
        /// <returns></returns>
        public int createSession(
                                    string SessionID,
                                    string UserID,
                                    string LoggedInClientIP
                                )
        {
            try
            {
                // Need to call through the ADO wrapper or UOW pattern class. Please replace asap.
                string strSql = string.Empty;
                SqlConnection objConnection = new SqlConnection(Helpers.ConnectionString);
                using (objConnection as IDisposable)
                {
                    objConnection.Open();
                    SqlCommand objCommand = new SqlCommand();
                    using (objCommand as IDisposable)
                    {
                        objCommand.Connection = objConnection;
                        objCommand.Parameters.AddWithValue("@SessionID", SessionID);
                        objCommand.Parameters.AddWithValue("@UserID", UserID);
                        objCommand.Parameters.AddWithValue("@LoggedInClientIP", LoggedInClientIP);
                        objCommand.CommandText = "INSERT INTO Portalsession (SessionID,UserID,LoggedInClientIP) "+
                                                 " VALUES ('"+ 
                                                 objCommand.Parameters["@SessionID"].Value.ToString() + "','"+
                                                 objCommand.Parameters["@UserID"].Value.ToString() + "','"+
                                                 objCommand.Parameters["@LoggedInClientIP"].Value.ToString() +
                                                 "')";
                        objCommand.ExecuteNonQuery();
                    }
                    objCommand.Dispose();
                    objCommand = null;
                    objConnection.Close();
                }
                objConnection.Dispose();
                objConnection = null;

            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
    }
}

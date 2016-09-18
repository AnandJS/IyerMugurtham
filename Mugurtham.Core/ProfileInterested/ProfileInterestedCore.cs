using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.UOW;
using Mugurtham.Common.Utilities;
using Mugurtham.Core.Profile.API;
using Mugurtham.Core.BasicInfo;
using Mugurtham.Core.Profile.View;
using Mugurtham.Core.Profile.Photo;
using System.Data.SqlClient;
using System.Data;

namespace Mugurtham.Core.ProfileInterested
{
    public class ProfileInterestedCore
    {
        public int Add(ref Mugurtham.Core.ProfileInterested.ProfileInterestedCoreEntity objProfileInterestedCoreEntity)
        {
            try
            {
                string strMappingID = string.Empty;
                string strViewerID = objProfileInterestedCoreEntity.ViewerID;
                string strInterestedInID = objProfileInterestedCoreEntity.InterestedInID;
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.ProfileInterested.ProfileInterested objDTOProfileInterested = new DTO.ProfileInterested.ProfileInterested();
                    using (objDTOProfileInterested as IDisposable)
                    {
                        objDTOProfileInterested.ID = Helpers.primaryKey;
                        AssignDTOFromEntity(ref objDTOProfileInterested, ref objProfileInterestedCoreEntity);
                    }
                    List<Mugurtham.DTO.ProfileInterested.ProfileInterested> objProfileInterested = new List<DTO.ProfileInterested.ProfileInterested>();
                    using (objProfileInterested as IDisposable)
                    {
                        objProfileInterested = objIUnitOfWork.RepositoryProfileInterested.GetAll().ToList().
                        Where(p => p.ViewerID.Trim().ToLower() == strViewerID.Trim().ToLower() &&
                              p.InterestedInID.Trim().ToLower() == strInterestedInID.Trim().ToLower()).ToList();
                        foreach (DTO.ProfileInterested.ProfileInterested objProfiles in objProfileInterested)
                        {
                            strMappingID = objProfiles.ID;
                        }
                    }
                    if (objProfileInterested.Count == 0)
                    {
                        IUnitOfWork objIUnitOfWorkAdd = new UnitOfWork();
                        using (objIUnitOfWorkAdd as IDisposable)
                        {
                            objIUnitOfWorkAdd.RepositoryProfileInterested.Add(objDTOProfileInterested);
                            objIUnitOfWorkAdd.commit();
                            objDTOProfileInterested = null;
                        }
                        objIUnitOfWorkAdd = null;
                    }
                }
                objIUnitOfWork = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        public int Delete(string strViewerID, string strInterestedInID)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.ProfileInterested.ProfileInterested objProfileInterested = new DTO.ProfileInterested.ProfileInterested();
                    using (objProfileInterested as IDisposable)
                    {
                        objProfileInterested = objIUnitOfWork.RepositoryProfileInterested.GetAll().ToList().
                        Where(p => p.ViewerID.Trim().ToLower() == strViewerID.Trim().ToLower() &&
                              p.InterestedInID.Trim().ToLower() == strInterestedInID.Trim().ToLower()).FirstOrDefault();
                    }
                    if (objProfileInterested != null)
                    {
                        IUnitOfWork objIUnitOfWorkAdd = new UnitOfWork();
                        using (objIUnitOfWorkAdd as IDisposable)
                        {
                            objIUnitOfWorkAdd.RepositoryProfileInterested.Delete(objProfileInterested);
                            objIUnitOfWorkAdd.commit();
                        }
                        objIUnitOfWorkAdd = null;
                    }
                    objProfileInterested = null;
                }
                objIUnitOfWork = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }

        public int GetInterestedProfiles(string strConnectionString, string strGender,
            string strInterestedProfileID, string strSangamID,
           ref ProfileBasicViewEntity objProfileBasicViewEntity,
           ref Mugurtham.Core.Login.LoggedInUser objLoggedIn)
        {
            List<PhotoCoreEntity> objPhotoCoreEntityList = new List<PhotoCoreEntity>();
            List<ProfileBasicInfoViewCoreEntity> objProfileBasicInfoViewCoreEntityList = new List<ProfileBasicInfoViewCoreEntity>();
            try
            {
                if (objLoggedIn.roleID == Constants.RoleIDForUserProfile) // User Profiles 
                {
                    if (!string.IsNullOrWhiteSpace(objLoggedIn.BasicInfoCoreEntity.Gender))
                    {
                        if (objLoggedIn.BasicInfoCoreEntity.Gender.ToLower().Trim() == "male".ToLower().Trim())
                            strGender = "female";
                        else
                            strGender = "male";
                    }
                }
                using (SqlConnection objSqlConnection = new SqlConnection(strConnectionString))
                {
                    objSqlConnection.Open();
                    // 1.  create a command object identifying the stored procedure
                    SqlCommand objSqlCommand = new SqlCommand("uspGetInterestedProfiles", objSqlConnection);

                    // 2. set the command object so it knows to execute a stored procedure
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    objSqlCommand.Parameters.Add(new SqlParameter("@GENDER", strGender));
                    objSqlCommand.Parameters.Add(new SqlParameter("@InterestedID", strInterestedProfileID));
                    objSqlCommand.Parameters.Add(new SqlParameter("@SangamID", strSangamID));
                    // execute the command
                    using (SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader())
                    {
                        while (objSqlDataReader.Read())
                        {
                            ProfileBasicInfoViewCoreEntity objProfileBasicInfoViewCoreEntity = new ProfileBasicInfoViewCoreEntity();
                            objProfileBasicInfoViewCoreEntity.SangamProfileID = objSqlDataReader["SangamProfileID"].ToString();
                            objProfileBasicInfoViewCoreEntity.MugurthamProfileID = objSqlDataReader["MugurthamProfileID"].ToString();
                            objProfileBasicInfoViewCoreEntity.Name = objSqlDataReader["Name"].ToString();
                            objProfileBasicInfoViewCoreEntity.Gender = objSqlDataReader["Gender"].ToString();
                            objProfileBasicInfoViewCoreEntity.Education = objSqlDataReader["Education"].ToString();
                            objProfileBasicInfoViewCoreEntity.Location = objSqlDataReader["Location"].ToString();
                            objProfileBasicInfoViewCoreEntity.Occupation = objSqlDataReader["Occupation"].ToString();
                            objProfileBasicInfoViewCoreEntity.SangamID = objSqlDataReader["SangamID"].ToString();
                            objProfileBasicInfoViewCoreEntity.SangamName = objSqlDataReader["SangamName"].ToString();
                            objProfileBasicInfoViewCoreEntity.SubCaste = objSqlDataReader["Subcaste"].ToString();
                            objProfileBasicInfoViewCoreEntity.Star = objSqlDataReader["Star"].ToString();
                            objProfileBasicInfoViewCoreEntity.AboutMe = objSqlDataReader["AboutMe"].ToString();
                            if (!string.IsNullOrEmpty(objSqlDataReader["Age"].ToString()))
                                objProfileBasicInfoViewCoreEntity.Age = Convert.ToInt32(objSqlDataReader["Age"].ToString());
                            objProfileBasicInfoViewCoreEntityList.Add(objProfileBasicInfoViewCoreEntity);
                        }
                        if (objSqlDataReader.NextResult())
                        {
                            while (objSqlDataReader.Read())
                            {
                                PhotoCoreEntity objPhotoCoreEntity = new PhotoCoreEntity();
                                using (objPhotoCoreEntity as IDisposable)
                                {
                                    objPhotoCoreEntity.ID = objSqlDataReader["ID"].ToString();
                                    objPhotoCoreEntity.ProfileID = objSqlDataReader["ProfileID"].ToString();
                                    objPhotoCoreEntity.PhotoPath = objSqlDataReader["PhotoPath"].ToString();
                                    objPhotoCoreEntity.IsProfilePic = Convert.ToDecimal(objSqlDataReader["IsProfilePic"].ToString());
                                    objPhotoCoreEntityList.Add(objPhotoCoreEntity);
                                }
                                objPhotoCoreEntity = null;
                            }
                        }
                        objProfileBasicViewEntity.ProfileBasicInfoViewCoreEntityList = objProfileBasicInfoViewCoreEntityList;
                        objProfileBasicViewEntity.PhotoCoreEntityList = objPhotoCoreEntityList;
                        objSqlDataReader.Close();
                    }
                    objSqlCommand.Cancel();
                    objSqlCommand.Dispose();
                    objSqlConnection.Close();
                    objSqlConnection.Dispose();

                }
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        public int GetInterestedInMeProfiles(string strConnectionString, string strGender,
                string strInterestedProfileID, string strSangamID,
               ref ProfileBasicViewEntity objProfileBasicViewEntity,
               ref Mugurtham.Core.Login.LoggedInUser objLoggedIn)
        {
            List<PhotoCoreEntity> objPhotoCoreEntityList = new List<PhotoCoreEntity>();
            try
            {
                List<ProfileBasicInfoViewCoreEntity> objProfileBasicInfoViewCoreEntityList = new List<ProfileBasicInfoViewCoreEntity>();
                if (objLoggedIn.roleID == Constants.RoleIDForUserProfile) // User Profiles 
                {
                    if (!string.IsNullOrWhiteSpace(objLoggedIn.BasicInfoCoreEntity.Gender))
                    {
                        if (objLoggedIn.BasicInfoCoreEntity.Gender.ToLower().Trim() == "male".ToLower().Trim())
                            strGender = "female";
                        else
                            strGender = "male";
                    }
                }
                using (SqlConnection objSqlConnection = new SqlConnection(strConnectionString))
                {
                    objSqlConnection.Open();
                    // 1.  create a command object identifying the stored procedure
                    SqlCommand objSqlCommand = new SqlCommand("uspGetInterestedInMeProfiles", objSqlConnection);

                    // 2. set the command object so it knows to execute a stored procedure
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    objSqlCommand.Parameters.Add(new SqlParameter("@GENDER", strGender));
                    objSqlCommand.Parameters.Add(new SqlParameter("@InterestedID", strInterestedProfileID));
                    objSqlCommand.Parameters.Add(new SqlParameter("@SangamID", strSangamID));
                    // execute the command
                    using (SqlDataReader objSqlDataReader = objSqlCommand.ExecuteReader())
                    {
                        while (objSqlDataReader.Read())
                        {
                            ProfileBasicInfoViewCoreEntity objProfileBasicInfoViewCoreEntity = new ProfileBasicInfoViewCoreEntity();
                            objProfileBasicInfoViewCoreEntity.SangamProfileID = objSqlDataReader["SangamProfileID"].ToString();
                            objProfileBasicInfoViewCoreEntity.MugurthamProfileID = objSqlDataReader["MugurthamProfileID"].ToString();
                            objProfileBasicInfoViewCoreEntity.Name = objSqlDataReader["Name"].ToString();
                            objProfileBasicInfoViewCoreEntity.Gender = objSqlDataReader["Gender"].ToString();
                            objProfileBasicInfoViewCoreEntity.Education = objSqlDataReader["Education"].ToString();
                            objProfileBasicInfoViewCoreEntity.Location = objSqlDataReader["Location"].ToString();
                            objProfileBasicInfoViewCoreEntity.Occupation = objSqlDataReader["Occupation"].ToString();
                            objProfileBasicInfoViewCoreEntity.SangamID = objSqlDataReader["SangamID"].ToString();
                            objProfileBasicInfoViewCoreEntity.SangamName = objSqlDataReader["SangamName"].ToString();
                            objProfileBasicInfoViewCoreEntity.SubCaste = objSqlDataReader["Subcaste"].ToString();
                            objProfileBasicInfoViewCoreEntity.Star = objSqlDataReader["Star"].ToString();
                            objProfileBasicInfoViewCoreEntity.AboutMe = objSqlDataReader["AboutMe"].ToString();
                            if (!string.IsNullOrEmpty(objSqlDataReader["Age"].ToString()))
                                objProfileBasicInfoViewCoreEntity.Age = Convert.ToInt32(objSqlDataReader["Age"].ToString());
                            objProfileBasicInfoViewCoreEntityList.Add(objProfileBasicInfoViewCoreEntity);
                        }
                        if (objSqlDataReader.NextResult())
                        {
                            while (objSqlDataReader.Read())
                            {
                                PhotoCoreEntity objPhotoCoreEntity = new PhotoCoreEntity();
                                using (objPhotoCoreEntity as IDisposable)
                                {
                                    objPhotoCoreEntity.ID = objSqlDataReader["ID"].ToString();
                                    objPhotoCoreEntity.ProfileID = objSqlDataReader["ProfileID"].ToString();
                                    objPhotoCoreEntity.PhotoPath = objSqlDataReader["PhotoPath"].ToString();
                                    objPhotoCoreEntity.IsProfilePic = Convert.ToDecimal(objSqlDataReader["IsProfilePic"].ToString());
                                    objPhotoCoreEntityList.Add(objPhotoCoreEntity);
                                }
                                objPhotoCoreEntity = null;
                            }
                        }
                        objProfileBasicViewEntity.ProfileBasicInfoViewCoreEntityList = objProfileBasicInfoViewCoreEntityList;
                        objProfileBasicViewEntity.PhotoCoreEntityList = objPhotoCoreEntityList;
                        objSqlDataReader.Close();
                    }
                    objSqlCommand.Cancel();
                    objSqlCommand.Dispose();
                    objSqlConnection.Close();
                    objSqlConnection.Dispose();

                }
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        public bool isInterestedProfile(string strViewerID, string strInterestedInID)
        {
            bool boolInterestedProfile = false;
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.ProfileInterested.ProfileInterested objProfileInterested = new DTO.ProfileInterested.ProfileInterested();
                    using (objProfileInterested as IDisposable)
                    {
                        objProfileInterested = objIUnitOfWork.RepositoryProfileInterested.GetAll().ToList().
                        Where(p => p.ViewerID.Trim().ToLower() == strViewerID.Trim().ToLower() &&
                              p.InterestedInID.Trim().ToLower() == strInterestedInID.Trim().ToLower()).FirstOrDefault();
                    }
                    if (objProfileInterested != null)
                        boolInterestedProfile = true;
                }
                objIUnitOfWork = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return boolInterestedProfile;
        }
        private int AssignDTOFromEntity(ref Mugurtham.DTO.ProfileInterested.ProfileInterested objDTOProfileInterested, ref Mugurtham.Core.ProfileInterested.ProfileInterestedCoreEntity objProfileInterestedCoreEntity)
        {
            try
            {
                objDTOProfileInterested.ViewerID = objProfileInterestedCoreEntity.ViewerID;
                objDTOProfileInterested.InterestedInID = objProfileInterestedCoreEntity.InterestedInID;
                objDTOProfileInterested.InterestedDate = DateTime.Now;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        private int AssignEntityFromDTO(ref ProfileInterestedCoreEntity objProfileInterestedCoreEntity, Mugurtham.DTO.ProfileInterested.ProfileInterested objDTOProfileInterested)
        {
            try
            {
                objProfileInterestedCoreEntity.ID = objDTOProfileInterested.ID;
                objProfileInterestedCoreEntity.ViewerID = objDTOProfileInterested.ViewerID;
                objProfileInterestedCoreEntity.InterestedInID = objDTOProfileInterested.InterestedInID;
                objProfileInterestedCoreEntity.InterestedDate = objDTOProfileInterested.InterestedDate;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
    }
}

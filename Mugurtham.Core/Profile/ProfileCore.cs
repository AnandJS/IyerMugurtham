using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.Core.BasicInfo;
using Mugurtham.Core.Career;
using Mugurtham.Core.Contact;
using Mugurtham.Core.Family;
using Mugurtham.Core.Location;
using Mugurtham.Core.Reference;
using Mugurtham.Core.Raasi;
using Mugurtham.Core.Amsam;
using Mugurtham.Core.Sangam;
using Mugurtham.Core.Login;
using Mugurtham.Common.Utilities;
using Mugurtham.UOW;
using Mugurtham.Core.User;
using Mugurtham.Core.Profile.View;
using Mugurtham.Core.Profile.Photo;
using System.Data.SqlClient;
using System.Data;

namespace Mugurtham.Core.Profile.API
{
    /// <summary>
    /// Wrapper Class for all reistration form core classes
    /// </summary>
    public class ProfileCore
    {
        public BasicInfoCoreEntity BasicInfoCoreEntity { get; set; }
        public CareerCoreEntity CareerCoreEntity { get; set; }
        public ContactCoreEntity ContactCoreEntity { get; set; }
        public FamilyCoreEntity FamilyCoreEntity { get; set; }
        public LocationCoreEntity LocationCoreEntity { get; set; }
        public ReferenceCoreEntity ReferenceCoreEntity { get; set; }
        public SangamCoreEntity SangamCoreEntity { get; set; }
        public RaasiCoreEntity RaasiCoreEntity { get; set; }
        public AmsamCoreEntity AmsamCoreEntity { get; set; }
        //The below properties are used onnly for filtering angularjs array properries
        // Filters for the General Search
        public string SangamID { get; set; }
        public string Gender { get; set; }
        public string Star { get; set; }
        public string SubCaste { get; set; }
        public decimal? Age { get; set; }
        public string profileDOB { get; set; }
        // Validation property for Viewing Full Profile
        public bool validateFullViewAccess { get; set; }
        //Holds ProfilePhoto list
        public List<Photo.PhotoCoreEntity> PhotoCoreEntityList { get; set; }
        //Holds UserEntity object
        public UserCoreEntity UserCoreEntity { get; set; }
        // SangamAdminProfileList Page filter property
        public string MugurthamProfileID { get; set; }
        public string SangamProfiledID { get; set; }


        /// <summary>
        /// Creates a new row in all profile registration table for the passed profileID
        /// </summary>
        /// <param name="strProfileID">New ProfileID to create in all registration tables</param>
        /// <returns></returns>
        public int Add(ref BasicInfoCoreEntity objBasicInfoCoreEntity, out string strProfileID, Mugurtham.Core.Login.LoggedInUser objLoggedIn)
        {

            strProfileID = string.Empty;
            string strUserID = string.Empty;
            SangamCore objSangamCore = new SangamCore();
            try
            {
                using (objSangamCore as IDisposable)
                {
                    objSangamCore.GetNewProfileID(out strProfileID, objLoggedIn);
                    Mugurtham.Core.Sangam.SangamCoreEntity objSangamCoreEntity = new SangamCoreEntity();
                    using (objSangamCoreEntity as IDisposable)
                    {
                        objSangamCoreEntity = objSangamCore.GetByID(objLoggedIn.sangamID);
                        if (string.IsNullOrEmpty(objSangamCoreEntity.LastProfileIDNo.ToString()))
                            return -1;
                        objSangamCoreEntity.LastProfileIDNo += 1;
                        objSangamCore.Edit(ref objSangamCoreEntity);
                    }
                    objSangamCoreEntity = null;
                }
                objSangamCore = null;

                User.UserCore objUserCore = new User.UserCore();
                using (objUserCore as IDisposable)
                {
                    User.UserCoreEntity objUserCoreEntity = new User.UserCoreEntity();
                    using (objUserCoreEntity as IDisposable)
                    {
                        objUserCoreEntity.ID = Helpers.primaryKey;
                        objUserCoreEntity.Name = objBasicInfoCoreEntity.Name;
                        objUserCoreEntity.LoginID = strProfileID;
                        objUserCoreEntity.Password = strProfileID; // Helpers.passwordGenerator();
                        objUserCoreEntity.SangamID = objLoggedIn.sangamID;
                        objUserCoreEntity.RoleID = Constants.RoleIDForUserProfile;
                        objUserCoreEntity.ThemeID = Constants.ThemeBootstrap;
                        objUserCoreEntity.LocaleID = Constants.LocaleUSEnglish;
                        objUserCoreEntity.IsActivated = "1"; // Activated by default
                        objUserCoreEntity.HomePagePath = Constants.HomePagePathForProfileUser;
                        objUserCore.Add(ref objUserCoreEntity, out strUserID);
                    }
                    objUserCoreEntity = null;
                }
                objUserCore = null;

                BasicInfoCore objBasicInfoCore = new BasicInfoCore();
                using (objBasicInfoCore as IDisposable)
                {
                    objBasicInfoCoreEntity.ProfileID = strProfileID;
                    objBasicInfoCoreEntity.ElanUserID = strUserID;
                    objBasicInfoCoreEntity.SangamID = objLoggedIn.sangamID;
                    objBasicInfoCore.Add(ref objBasicInfoCoreEntity);
                }
                objBasicInfoCore = null;

                CareerCore objCareerCore = new CareerCore();
                using (objCareerCore as IDisposable)
                {
                    CareerCoreEntity objCareerCoreEntity = new CareerCoreEntity();
                    using (objCareerCoreEntity as IDisposable)
                    {
                        objCareerCoreEntity.ProfileID = strProfileID;
                        objCareerCore.Add(ref objCareerCoreEntity);
                    }
                    objCareerCoreEntity = null;
                }
                objCareerCore = null;

                ContactCore objContactCore = new ContactCore();
                using (objContactCore as IDisposable)
                {
                    ContactCoreEntity objContactCoreEntity = new ContactCoreEntity();
                    using (objContactCoreEntity as IDisposable)
                    {
                        objContactCoreEntity.ProfileID = strProfileID;
                        objContactCore.Add(ref objContactCoreEntity);
                    }
                    objContactCoreEntity = null;
                }
                objContactCore = null;

                FamilyCore objFamilyCore = new FamilyCore();
                using (objFamilyCore as IDisposable)
                {
                    FamilyCoreEntity objFamilyCoreEntity = new FamilyCoreEntity();
                    using (objFamilyCoreEntity as IDisposable)
                    {
                        objFamilyCoreEntity.ProfileID = strProfileID;
                        objFamilyCore.Add(ref objFamilyCoreEntity);
                    }
                    objFamilyCoreEntity = null;
                }
                objFamilyCore = null;

                LocationCore objLocationCore = new LocationCore();
                using (objLocationCore as IDisposable)
                {
                    LocationCoreEntity objLocationCoreEntity = new LocationCoreEntity();
                    using (objLocationCoreEntity as IDisposable)
                    {
                        objLocationCoreEntity.ProfileID = strProfileID;
                        objLocationCore.Add(ref objLocationCoreEntity);
                    }
                    objLocationCoreEntity = null;
                }
                objLocationCore = null;

                ReferenceCore objReferenceCore = new ReferenceCore();
                using (objReferenceCore as IDisposable)
                {
                    ReferenceCoreEntity objReferenceCoreEntity = new ReferenceCoreEntity();
                    using (objReferenceCoreEntity as IDisposable)
                    {
                        objReferenceCoreEntity.ProfileID = strProfileID;
                        objReferenceCore.Add(ref objReferenceCoreEntity);
                    }
                    objReferenceCoreEntity = null;
                }
                objReferenceCore = null;
                RaasiCore objRaasiCore = new RaasiCore();
                using (objRaasiCore as IDisposable)
                {
                    RaasiCoreEntity objRaasiCoreEntity = new RaasiCoreEntity();
                    using (objRaasiCoreEntity as IDisposable)
                    {
                        objRaasiCoreEntity.ProfileID = strProfileID;
                        objRaasiCore.Add(ref objRaasiCoreEntity);
                    }
                    objRaasiCoreEntity = null;
                }
                objRaasiCore = null;
                AmsamCore objAmsamCore = new AmsamCore();
                using (objAmsamCore as IDisposable)
                {
                    AmsamCoreEntity objAmsamCoreEntity = new AmsamCoreEntity();
                    using (objAmsamCoreEntity as IDisposable)
                    {
                        objAmsamCoreEntity.ProfileID = strProfileID;
                        objAmsamCore.Add(ref objAmsamCoreEntity);
                    }
                    objAmsamCoreEntity = null;
                }
                objAmsamCore = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strProfileID"></param>
        /// <param name="objProfileCore"></param>
        /// <param name="objLoggedIn"></param>
        /// <param name="boolAddAllEntities">Optional argument to add all profile entities to the prfoilecore object -- added to consider performance optimization</param>
        /// <returns></returns>
        public int GetByProfileID(string strProfileID, out ProfileCore objProfileCore, Mugurtham.Core.Login.LoggedInUser objLoggedIn = null, bool boolAddAllEntities = false)
        {
            objProfileCore = null;
            try
            {
                objProfileCore = new ProfileCore();
                if (string.IsNullOrWhiteSpace(strProfileID))
                    return -1;
                //Adding all entities to Profile object
                using (objProfileCore as IDisposable)
                {
                    // Assign the user object for this profileID
                    objProfileCore.UserCoreEntity = getUserEntity(strProfileID);

                    BasicInfoCore objBICore = new BasicInfoCore();
                    using (objBICore as IDisposable)
                    {
                        //Check profile restrictions
                        // if allowed then process the rest of the code
                        // else return error code
                        IUnitOfWork objIUnitOfWork = new UnitOfWork();
                        using (objIUnitOfWork as IDisposable)
                        {
                            BasicInfoCoreEntity objBasicInfoCoreEntity = new BasicInfo.BasicInfoCoreEntity();
                            using (objBasicInfoCoreEntity as IDisposable)
                            {
                                if (objIUnitOfWork.RepositoryBasicInfo.getByProfileID(strProfileID) != null)
                                {
                                    objProfileCore.BasicInfoCoreEntity = objBasicInfoCoreEntity;
                                    objBICore.AssignEntityFromDTO(objProfileCore.BasicInfoCoreEntity, objIUnitOfWork.RepositoryBasicInfo.getByProfileID(strProfileID));
                                }
                                else
                                {
                                    return -1; // Error Code
                                }
                            }
                            objBasicInfoCoreEntity = null;
                        }
                        objIUnitOfWork = null;
                        objProfileCore.SangamID = objProfileCore.BasicInfoCoreEntity.SangamID;
                        objProfileCore.Gender = objProfileCore.BasicInfoCoreEntity.Gender;
                        objProfileCore.Star = objProfileCore.BasicInfoCoreEntity.Star;
                        objProfileCore.SubCaste = objProfileCore.BasicInfoCoreEntity.SubCaste;
                        objProfileCore.Age = objProfileCore.BasicInfoCoreEntity.Age;
                        objProfileCore.profileDOB = objProfileCore.BasicInfoCoreEntity.DOB.ToString();
                        objProfileCore.MugurthamProfileID = objProfileCore.BasicInfoCoreEntity.ProfileID;
                        objProfileCore.SangamProfiledID = objProfileCore.BasicInfoCoreEntity.SangamProfileID;
                    }
                    objBICore = null;

                    Photo.PhotoCore objPhotoCore = new Photo.PhotoCore();
                    using (objPhotoCore as IDisposable)
                    {
                        List<Mugurtham.Core.Profile.Photo.PhotoCoreEntity> objPhotoCoreEntityList = new List<Mugurtham.Core.Profile.Photo.PhotoCoreEntity>();
                        objProfileCore.GetProfilePhotos(ref objPhotoCoreEntityList, strProfileID);
                        objProfileCore.PhotoCoreEntityList = objPhotoCoreEntityList;
                    }
                    objPhotoCore = null;
                    CareerCore objCareerCore = new CareerCore();
                    using (objCareerCore as IDisposable)
                        objProfileCore.CareerCoreEntity = objCareerCore.GetByProfileID(strProfileID);
                    objCareerCore = null;
                    LocationCore objLocationCore = new LocationCore();
                    using (objLocationCore as IDisposable)
                        objProfileCore.LocationCoreEntity = objLocationCore.GetByProfileID(strProfileID);
                    objLocationCore = null;
                    ContactCore objContactCore = new ContactCore();
                    using (objContactCore as IDisposable)
                        objProfileCore.ContactCoreEntity = objContactCore.GetByProfileID(strProfileID);
                    objContactCore = null;
                    FamilyCore objFamilyCore = new FamilyCore();
                    using (objFamilyCore as IDisposable)
                        objProfileCore.FamilyCoreEntity = objFamilyCore.GetByProfileID(strProfileID);
                    objFamilyCore = null;
                    ReferenceCore objReferenceCore = new ReferenceCore();
                    using (objReferenceCore as IDisposable)
                        objProfileCore.ReferenceCoreEntity = objReferenceCore.GetByProfileID(strProfileID);
                    objReferenceCore = null;
                    SangamCore objSangamCore = new SangamCore();
                    using (objSangamCore as IDisposable)
                        objProfileCore.SangamCoreEntity = objSangamCore.GetByID(objProfileCore.BasicInfoCoreEntity.SangamID);
                    objReferenceCore = null;
                    RaasiCore objRaasiCore = new RaasiCore();
                    using (objRaasiCore as IDisposable)
                        objProfileCore.RaasiCoreEntity = objRaasiCore.GetByProfileID(strProfileID);
                    objRaasiCore = null;
                    AmsamCore objAmsamCore = new AmsamCore();
                    using (objAmsamCore as IDisposable)
                        objProfileCore.AmsamCoreEntity = objAmsamCore.GetByProfileID(strProfileID);
                    objRaasiCore = null;

                    validateUserAccessToThisProfile(objProfileCore.BasicInfoCoreEntity.ProfileID, ref objProfileCore, objLoggedIn);
                }
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        private int validateUserAccessToThisProfile(string strProfileID, ref ProfileCore objProfileCore, Mugurtham.Core.Login.LoggedInUser objLoggedIn = null)
        {
            objProfileCore.validateFullViewAccess = false;
            try
            {
                if (objLoggedIn != null)
                {
                    // When LoggedIn user is this Profile user then grant access to view
                    if (objLoggedIn.LoginID == strProfileID)
                        objProfileCore.validateFullViewAccess = true;
                    // When LoggedIn user is the Sangam Admin of this Profile user then grant access to view
                    else if ((objLoggedIn.sangamID == objProfileCore.SangamID)
                        && (objLoggedIn.roleID == Constants.RoleIDForSangamAdmin))
                        objProfileCore.validateFullViewAccess = true;
                    // When LoggedIn user is the Member of this Profile users Sangam then grant access to view
                    else if ((objLoggedIn.sangamID == objProfileCore.SangamCoreEntity.ID)
                        && (objLoggedIn.roleID == Constants.RoleIDForUserProfile))
                        objProfileCore.validateFullViewAccess = true;
                    // When LoggedIn user is the Mugurtham Admin then grant access
                    else if (objLoggedIn.roleID == Constants.RoleIDForMugurthamAdmin)
                        objProfileCore.validateFullViewAccess = true;
                }
                if (!objProfileCore.validateFullViewAccess)
                {
                    //setEmptyInfoToProfile(ref objProfileCore);
                }
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        /// <summary>
        /// Preventing Hacking - Through Inspect Element when display hidden is disabled
        /// Donot empty the information containing in the Basic Information
        /// </summary>
        /// <returns></returns>
        public int setEmptyInfoToProfile(ref ProfileCore objProfileCore)
        {
            try
            {
                // Reset BasicInformation Object to Empty - [Never Nullify it]            
                objProfileCore.BasicInfoCoreEntity.AboutMe = string.Empty;
                objProfileCore.BasicInfoCoreEntity.Age = 0;
                objProfileCore.BasicInfoCoreEntity.AnyDhosham = string.Empty;
                objProfileCore.BasicInfoCoreEntity.BloodGroup = string.Empty;
                objProfileCore.BasicInfoCoreEntity.BodyType = string.Empty;
                objProfileCore.BasicInfoCoreEntity.Caste = string.Empty;
                objProfileCore.BasicInfoCoreEntity.ChildrenLivingStatus = string.Empty;
                objProfileCore.BasicInfoCoreEntity.Complexion = string.Empty;
                objProfileCore.BasicInfoCoreEntity.Gender = string.Empty;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        public int GetAll(ref List<ProfileCore> objProfileCoreList, string strGender, string strSangamID)
        {
            try
            {
                BasicInfoCore objBasicInfoCore = new BasicInfoCore();
                using (objBasicInfoCore as IDisposable)
                {
                    List<BasicInfoCoreEntity> objBasicInfoCoreEntityList = new List<BasicInfoCoreEntity>();
                    IUnitOfWork objIUnitOfWork = new UnitOfWork();
                    using (objIUnitOfWork as IDisposable)
                    {
                        if ((objIUnitOfWork.RepositoryBasicInfo.getAllProfiles(strGender, strSangamID) != null) &&
                            (objIUnitOfWork.RepositoryBasicInfo.getAllProfiles(strGender, strSangamID).Count > 0))
                        {
                            List<Mugurtham.DTO.Profile.BasicInfo> objListBasicInfo = new List<Mugurtham.DTO.Profile.BasicInfo>();
                            objListBasicInfo = objIUnitOfWork.RepositoryBasicInfo.getAllProfiles(strGender, strSangamID);
                            if (objListBasicInfo != null && objListBasicInfo.Count > 0)
                            {
                                foreach (Mugurtham.DTO.Profile.BasicInfo objBasicInfo in objListBasicInfo)
                                {
                                    using (objBasicInfo as IDisposable)
                                    {
                                        BasicInfoCoreEntity objBasicInfoCoreEntity = new BasicInfoCoreEntity();
                                        using (objBasicInfoCoreEntity as IDisposable)
                                        {
                                            objBasicInfoCore.AssignEntityFromDTO(objBasicInfoCoreEntity, objBasicInfo);
                                            objBasicInfoCoreEntityList.Add(objBasicInfoCoreEntity);
                                        }
                                        objBasicInfoCoreEntity = null;
                                    }
                                }
                            }
                        }
                    }
                    objIUnitOfWork = null;
                    foreach (BasicInfoCoreEntity objBasicInfoCoreEntity in objBasicInfoCoreEntityList)
                    {
                        ProfileCore objProfileCore = null;
                        GetByProfileID(objBasicInfoCoreEntity.ProfileID, out objProfileCore);
                        objProfileCoreList.Add(objProfileCore);
                        using (objProfileCore as IDisposable) { }
                        objProfileCore = null;
                    }
                }
                objBasicInfoCore = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }

        /*public int GetRecentlyJoined(ref List<ProfileCore> objProfileCoreList, string strGender, string strSangmID)
        {
            BasicInfoCore objBasicInfoCore = new BasicInfoCore();
            using (objBasicInfoCore as IDisposable)
            {
                List<BasicInfoCoreEntity> objBasicInfoCoreEntityList = new List<BasicInfoCoreEntity>();
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    if ((objIUnitOfWork.RepositoryBasicInfo.getRecentlyAdded(strGender, strSangmID) != null) &&
                        (objIUnitOfWork.RepositoryBasicInfo.getRecentlyAdded(strGender, strSangmID).Count > 0))
                    {
                        List<Mugurtham.DTO.Profile.BasicInfo> objListBasicInfo = new List<Mugurtham.DTO.Profile.BasicInfo>();
                        objListBasicInfo = objIUnitOfWork.RepositoryBasicInfo.getRecentlyAdded(strGender, strSangmID);
                        if (objListBasicInfo != null && objListBasicInfo.Count > 0)
                        {
                            foreach (Mugurtham.DTO.Profile.BasicInfo objBasicInfo in objListBasicInfo)
                            {
                                using (objBasicInfo as IDisposable)
                                {
                                    BasicInfoCoreEntity objBasicInfoCoreEntity = new BasicInfoCoreEntity();
                                    using (objBasicInfoCoreEntity as IDisposable)
                                    {
                                        objBasicInfoCore.AssignEntityFromDTO(objBasicInfoCoreEntity, objBasicInfo);
                                        objBasicInfoCoreEntityList.Add(objBasicInfoCoreEntity);
                                    }
                                    objBasicInfoCoreEntity = null;
                                }
                            }
                        }
                    }
                }
                objIUnitOfWork = null;
                foreach (BasicInfoCoreEntity objBasicInfoCoreEntity in objBasicInfoCoreEntityList)
                {
                    ProfileCore objProfileCore = null;
                    GetByProfileID(objBasicInfoCoreEntity.ProfileID, out objProfileCore);
                    objProfileCoreList.Add(objProfileCore);
                    using (objProfileCore as IDisposable) { }
                    objProfileCore = null;
                }
            }
            objBasicInfoCore = null;
            return 0;
        }*/
        public int GetRecentlyJoinedProfiles(string strConnectionString, string strGender, string strSangamID,
              ref ProfileBasicViewEntity objProfileBasicViewEntity,
              ref Mugurtham.Core.Login.LoggedInUser objLoggedIn)
        {
            try
            {
                List<PhotoCoreEntity> objPhotoCoreEntityList = new List<PhotoCoreEntity>();
                List<ProfileBasicInfoViewCoreEntity> objProfileBasicInfoViewCoreEntityList = new List<ProfileBasicInfoViewCoreEntity>();
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
                using (SqlConnection objSqlConnection = new SqlConnection(strConnectionString))
                {
                    objSqlConnection.Open();
                    // 1.  create a command object identifying the stored procedure
                    SqlCommand objSqlCommand = new SqlCommand("UspGetProfilesJoinedRecently", objSqlConnection);

                    // 2. set the command object so it knows to execute a stored procedure
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    objSqlCommand.Parameters.Add(new SqlParameter("@GENDER", strGender));
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
        public int GetHighlightedProfiles(string strConnectionString, string strGender, string strSangamID,
              ref ProfileBasicViewEntity objProfileBasicViewEntity,
              ref Mugurtham.Core.Login.LoggedInUser objLoggedIn)
        {
            try
            {
                List<PhotoCoreEntity> objPhotoCoreEntityList = new List<PhotoCoreEntity>();
                List<ProfileBasicInfoViewCoreEntity> objProfileBasicInfoViewCoreEntityList = new List<ProfileBasicInfoViewCoreEntity>();
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
                using (SqlConnection objSqlConnection = new SqlConnection(strConnectionString))
                {
                    objSqlConnection.Open();
                    // 1.  create a command object identifying the stored procedure
                    SqlCommand objSqlCommand = new SqlCommand("uspGetHighlightedProfiles", objSqlConnection);

                    // 2. set the command object so it knows to execute a stored procedure
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    objSqlCommand.Parameters.Add(new SqlParameter("@GENDER", strGender));
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
        public int GetViewedProfiles(string strConnectionString, string strGender,
               string strViewdProfileID, string strSangamID,
              ref ProfileBasicViewEntity objProfileBasicViewEntity,
              ref Mugurtham.Core.Login.LoggedInUser objLoggedIn)
        {
            try
            {
                List<PhotoCoreEntity> objPhotoCoreEntityList = new List<PhotoCoreEntity>();
                List<ProfileBasicInfoViewCoreEntity> objProfileBasicInfoViewCoreEntityList = new List<ProfileBasicInfoViewCoreEntity>();
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
                using (SqlConnection objSqlConnection = new SqlConnection(strConnectionString))
                {
                    objSqlConnection.Open();
                    // 1.  create a command object identifying the stored procedure
                    SqlCommand objSqlCommand = new SqlCommand("uspGetViewedProfiles", objSqlConnection);

                    // 2. set the command object so it knows to execute a stored procedure
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    objSqlCommand.Parameters.Add(new SqlParameter("@GENDER", strGender));
                    objSqlCommand.Parameters.Add(new SqlParameter("@InterestedID", strViewdProfileID));
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



        public int GetProfilePhotos(ref List<Mugurtham.Core.Profile.Photo.PhotoCoreEntity> objPhotoCoreEntityList, string strProfileID)
        {
            try
            {
                IQueryable<DTO.Profile.Photo> objIQPhoto;
                Profile.Photo.PhotoCore objPhotoCore = new Photo.PhotoCore();
                using (objPhotoCore as IDisposable)
                    objPhotoCore.getProfilePhotos(strProfileID, out objIQPhoto);
                objPhotoCore = null;
                if (objIQPhoto != null)
                {
                    foreach (DTO.Profile.Photo objPhoto in objIQPhoto)
                    {
                        Mugurtham.Core.Profile.Photo.PhotoCoreEntity objPhotoCoreEntity = new Photo.PhotoCoreEntity();
                        using (objPhotoCoreEntity as IDisposable)
                        {
                            objPhotoCoreEntity.ID = objPhoto.ID;
                            objPhotoCoreEntity.IsProfilePic = objPhoto.IsProfilePic;
                            objPhotoCoreEntity.PhotoPath = objPhoto.PhotoPath;
                            objPhotoCoreEntity.ProfileID = objPhoto.ProfileID;
                            objPhotoCoreEntityList.Add(objPhotoCoreEntity);
                        }
                        objPhotoCoreEntity = null;
                    }
                }
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        private Mugurtham.Core.User.UserCoreEntity getUserEntity(string strProfileID)
        {
            Mugurtham.Core.User.UserCoreEntity objUserCoreEntity = null;
            try
            {
                Mugurtham.Core.User.UserCore objUserCore = new Mugurtham.Core.User.UserCore();
                using (objUserCore as IDisposable)
                {
                    objUserCoreEntity = new Mugurtham.Core.User.UserCoreEntity();
                    using (objUserCoreEntity as IDisposable)
                    {
                        objUserCoreEntity = objUserCore.GetByLoginID(strProfileID);
                    }
                }
                objUserCore = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return objUserCoreEntity;
        }

    }
}

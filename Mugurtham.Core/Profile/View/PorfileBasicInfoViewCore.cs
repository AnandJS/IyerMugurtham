using Mugurtham.Common.Utilities;
using Mugurtham.Core.Profile.Photo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Core.Profile.View
{
    /// <summary>
    /// This type returns the information for basic info view
    /// </summary>
    public class PorfileBasicInfoViewCore
    {
        public int GetAllProfiles(string strConnectionString, string strGender,
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
                    SqlCommand objSqlCommand = new SqlCommand("uspGetProfileBasicInfoView", objSqlConnection);

                    // 2. set the command object so it knows to execute a stored procedure
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    objSqlCommand.Parameters.Add(new SqlParameter("@GENDER", strGender));
                    objSqlCommand.Parameters.Add(new SqlParameter("@SangamID", objLoggedIn.sangamID));

                    //using (SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand))
                    //{
                    //    // Fill the DataSet using default values for DataTable names, etc
                    //    DataSet objDataSet = new DataSet();
                    //    objSqlDataAdapter.Fill(objDataSet);
                    //}

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

        public int GetAllProfilesBySangam(string strConnectionString, string strGender,
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
                    SqlCommand objSqlCommand = new SqlCommand("uspGetProfilesBySangam", objSqlConnection);

                    // 2. set the command object so it knows to execute a stored procedure
                    objSqlCommand.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    objSqlCommand.Parameters.Add(new SqlParameter("@GENDER", strGender));
                    objSqlCommand.Parameters.Add(new SqlParameter("@SangamID", objLoggedIn.sangamID));

                    //using (SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand))
                    //{
                    //    // Fill the DataSet using default values for DataTable names, etc
                    //    DataSet objDataSet = new DataSet();
                    //    objSqlDataAdapter.Fill(objDataSet);
                    //}

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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Mugurtham.Repository.ProfileInterested
{
    /// <summary>
    /// This class is used for implementaion of the IProfileInterested interface only
    /// </summary>
    public class ProfileInterested : GenericRepository<Mugurtham.DTO.ProfileInterested.ProfileInterested>, IProfileInterested
    {
        Mugurtham.DAL.MugurthamDBContext objMugurthamDBContext = null;
        public ProfileInterested(Mugurtham.DAL.MugurthamDBContext objDbContext)
            : base(objDbContext)
        {
            objMugurthamDBContext = objDbContext;
        }

        public List<Mugurtham.DTO.Profile.BasicInfo> GetInterestedProfiles(string strGender, string strInterestedProfileID, string strSangamID)
        {
            var paramGender = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@Gender",
                Value = strGender
            };
            var paramViewedID = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@ViewedID",
                Value = strInterestedProfileID
            };
            var paramSangamID = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@SangamID",
                Value = strSangamID
            };
            var objBasicInfo = objMugurthamDBContext.Database.SqlQuery<Mugurtham.DTO.Profile.BasicInfo>(
          "exec uspGetInterestedProfiles  @Gender,@ViewedID,@SangamID", paramGender, paramViewedID, paramSangamID).ToList<Mugurtham.DTO.Profile.BasicInfo>();
            return objBasicInfo;
        }
        public List<Mugurtham.DTO.Profile.BasicInfo> GetInterestedInMeProfiles(string strGender, string strInterestedProfileID, string strSangamID)
        {
            var paramGender = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@Gender",
                Value = strGender
            };
            var paramViewedID = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@ViewedID",
                Value = strInterestedProfileID
            };
            var paramSangamID = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@SangamID",
                Value = strSangamID
            };
            var objBasicInfo = objMugurthamDBContext.Database.SqlQuery<Mugurtham.DTO.Profile.BasicInfo>(
          "exec uspGetInterestedInMeProfiles  @Gender,@ViewedID,@SangamID", paramGender, paramViewedID, paramSangamID).ToList<Mugurtham.DTO.Profile.BasicInfo>();
            return objBasicInfo;
        }
      
    }
}

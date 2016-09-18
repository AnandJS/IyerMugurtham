using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Mugurtham.Repository.Profile.BasicInfo
{
    /// <summary>
    /// This class is used for implementaion of the IBasicInfo interface only
    /// </summary>    
    public class BasicInfo : GenericRepository<Mugurtham.DTO.Profile.BasicInfo>, IBasicInfo
    {
        Mugurtham.DAL.MugurthamDBContext objMugurthamDBContext = null;
        public BasicInfo(Mugurtham.DAL.MugurthamDBContext objDbContext)
            : base(objDbContext)
        {
            objMugurthamDBContext = objDbContext;
        }
        public Mugurtham.DTO.Profile.BasicInfo getByProfileID(string strProfileID)
        {
            var idParam = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@ProfileID",
                Value = strProfileID
            };
            var objBasicInfo = objMugurthamDBContext.Database.SqlQuery<Mugurtham.DTO.Profile.BasicInfo>(
           "exec uspGetByProfileID @ProfileID", idParam).ToList<Mugurtham.DTO.Profile.BasicInfo>().FirstOrDefault();
            return objBasicInfo;
        }
        public List<Mugurtham.DTO.Profile.BasicInfo> getAllProfiles(string strGender, string strSangamID)
        {
            var paramGender = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@Gender",
                Value = strGender
            };
            var paramSangam = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@SangamID",
                Value = strSangamID
            };
            var objBasicInfo = objMugurthamDBContext.Database.SqlQuery<Mugurtham.DTO.Profile.BasicInfo>(
           "exec uspGetAllProfiles  @Gender, @SangamID", paramGender, paramSangam).ToList<Mugurtham.DTO.Profile.BasicInfo>();
            return objBasicInfo;
        }
        public List<Mugurtham.DTO.Profile.BasicInfo> getRecentlyAdded(string strGender, string strSangamID)
        {
            var paramGender = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@Gender",
                Value = strGender
            };
            var paramSangamID = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@SangamID",
                Value = strSangamID
            };
            var objBasicInfo = objMugurthamDBContext.Database.SqlQuery<Mugurtham.DTO.Profile.BasicInfo>(
           "exec uspGetProfilesJoinedThisWeek  @Gender,@SangamID", paramGender, paramSangamID).ToList<Mugurtham.DTO.Profile.BasicInfo>();
            return objBasicInfo;
        }
        public List<Mugurtham.DTO.Profile.BasicInfo> getHighlightedProfiles(string strGender, string strSangamID)
        {
            var paramGender = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@Gender",
                Value = strGender
            };
            var paramSangamID = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@SangamID",
                Value = strSangamID
            };
            var objBasicInfo = objMugurthamDBContext.Database.SqlQuery<Mugurtham.DTO.Profile.BasicInfo>(
           "exec uspGetHighlightedProfiles  @Gender,@SangamID", paramGender, paramSangamID).ToList<Mugurtham.DTO.Profile.BasicInfo>();
            return objBasicInfo;
        }
        public List<Mugurtham.DTO.Profile.BasicInfo> getViewedProfiles(string strGender, string strViewedProfileID, string strSanagmID)
        {
            var paramGender = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@Gender",
                Value = strGender
            };
            var paramViewedID = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@ViewedID",
                Value = strViewedProfileID
            };
            var paramSangamID = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@SangamID",
                Value = strSanagmID
            };
            var objBasicInfo = objMugurthamDBContext.Database.SqlQuery<Mugurtham.DTO.Profile.BasicInfo>(
           "exec uspGetViewedProfiles  @Gender,@ViewedID,@SangamID", paramGender, paramViewedID, paramSangamID).ToList<Mugurtham.DTO.Profile.BasicInfo>();

            return objBasicInfo;
        }
    }
}

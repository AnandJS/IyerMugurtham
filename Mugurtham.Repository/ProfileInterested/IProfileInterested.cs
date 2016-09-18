using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Repository.ProfileInterested
{
    public interface IProfileInterested : IRepository<Mugurtham.DTO.ProfileInterested.ProfileInterested>
    {
        List<Mugurtham.DTO.Profile.BasicInfo> GetInterestedProfiles(string strGender, string strInterestedProfileID, string strSangamID);
        List<Mugurtham.DTO.Profile.BasicInfo> GetInterestedInMeProfiles(string strGender, string strInterestedProfileID, string strSangamID);
    }
}

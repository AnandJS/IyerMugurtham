using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.DTO.Profile;

namespace Mugurtham.Repository.Profile.BasicInfo
{
    public interface IBasicInfo : IRepository<Mugurtham.DTO.Profile.BasicInfo>
    {
        Mugurtham.DTO.Profile.BasicInfo getByProfileID(string ProfileID);
        List<Mugurtham.DTO.Profile.BasicInfo> getAllProfiles(string strGender, string strSangamID);
        List<Mugurtham.DTO.Profile.BasicInfo> getRecentlyAdded(string strGender, string strSangam);
        List<Mugurtham.DTO.Profile.BasicInfo> getHighlightedProfiles(string strGender, string strSangam);
        List<Mugurtham.DTO.Profile.BasicInfo> getViewedProfiles(string strGender, string strViewedProfileID, string strSanagmID);
    }
}

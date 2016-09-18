using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Repository.ProfileViewed
{
    public interface IProfileViewed : IRepository<Mugurtham.DTO.ProfileViewed.ProfileViewed>
    {
        IQueryable<Mugurtham.DTO.ProfileViewed.ProfileViewed> GetViewedProfiles(string ID);
    }
}

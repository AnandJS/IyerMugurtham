using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Mugurtham.Repository.ProfileViewed
{
    /// <summary>
    /// This class is used for implementaion of the IProfileViewed interface only
    /// </summary>
    public class ProfileViewed : GenericRepository<Mugurtham.DTO.ProfileViewed.ProfileViewed>, IProfileViewed
    {
        public ProfileViewed(DbContext objDbContext)
            : base(objDbContext)
        {
        }
        public IQueryable<Mugurtham.DTO.ProfileViewed.ProfileViewed> GetViewedProfiles(string ID)
        {
            return GetAll().Where(p => p.ViewerID == ID);
        }
    }
}

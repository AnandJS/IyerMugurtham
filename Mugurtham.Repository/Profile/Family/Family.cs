using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Mugurtham.Repository.Profile.Family
{
    /// <summary>
    /// This class is used for implementaion of the IFamily interface only
    /// </summary>
    public class Family : GenericRepository<Mugurtham.DTO.Profile.Family>, IFamily
    {
        public Family(DbContext objDbContext)
            : base(objDbContext)
        {
        }

        public IQueryable<Mugurtham.DTO.Profile.Family> GetFamilyType(string ID)
        {
            return GetAll().Where(p => p.ProfileID == ID);
        }
    }
}

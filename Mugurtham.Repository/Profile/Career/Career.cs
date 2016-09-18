using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Mugurtham.Repository.Profile.Career
{
    /// <summary>
    /// This class is used for implementaion of the Icareer interface only
    /// </summary>
    public class Career : GenericRepository<Mugurtham.DTO.Profile.Career>, ICareer
    {
        public Career(DbContext objDbContext)
            : base(objDbContext)
        {
        }
        
        public IQueryable<Mugurtham.DTO.Profile.Career> GetIncome(string ID)
        {
            return GetAll().Where(p => p.ProfileID == ID.ToLower());
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Mugurtham.Repository.Profile.Amsam
{
    /// <summary>
    /// This class is used for implementaion of the IRaasi interface only
    /// </summary> 
    public class Amsam : GenericRepository<Mugurtham.DTO.Profile.Amsam>, IAmsam
    {
        public Amsam(DbContext objDbContext)
            : base(objDbContext)
        {
        }
        public IQueryable<Mugurtham.DTO.Profile.Amsam> GetByProfileID(string ID)
        {
            return GetAll().Where(p => p.ProfileID == ID);
        }
    }
}

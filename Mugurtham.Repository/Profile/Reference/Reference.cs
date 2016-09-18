using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Mugurtham.Repository.Profile.Reference
{
    /// <summary>
    /// This class is used for implementaion of the IReference interface only
    /// </summary>
    public class Reference : GenericRepository<Mugurtham.DTO.Profile.Reference>, IReference
    {
        public Reference(DbContext objDbContext)
            : base(objDbContext)
        {
        }

        public IQueryable<Mugurtham.DTO.Profile.Reference> GetContactNumber(string ID)
        {
            return GetAll().Where(p => p.ProfileID == ID);
        }
    }
}

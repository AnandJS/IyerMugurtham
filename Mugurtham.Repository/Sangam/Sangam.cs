using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Mugurtham.Repository.Sangam
{
    /// <summary>
    /// This class is used for implementaion of the ISangam interface only
    /// </summary>
    public class Sangam : GenericRepository<Mugurtham.DTO.Sangam.Sangam>, ISangam
    {
        public Sangam(DbContext objDbContext)
            : base(objDbContext)
        {
        }

        public IQueryable<Mugurtham.DTO.Sangam.Sangam> GetSangamName(string ID)
        {
            return GetAll().Where(p => p.ID == ID);
        }
    }
}

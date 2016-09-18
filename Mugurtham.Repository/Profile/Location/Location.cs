using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Mugurtham.Repository.Profile.Location
{
    
    /// <summary>
    /// This class is used for implementaion of the ILocation interface only
    /// </summary>
    public class Location : GenericRepository<Mugurtham.DTO.Profile.Location>, ILocation
    {
        public Location(DbContext objDbContext)
            : base(objDbContext)
        {
        }

        public IQueryable<Mugurtham.DTO.Profile.Location> GetCitizenship(string ID)
        {
            return GetAll().Where(p => p.ProfileID == ID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Repository.Profile.Location
{
    public interface ILocation : IRepository<Mugurtham.DTO.Profile.Location>
    {
        IQueryable<Mugurtham.DTO.Profile.Location> GetCitizenship(string ProfileID);
    }
}

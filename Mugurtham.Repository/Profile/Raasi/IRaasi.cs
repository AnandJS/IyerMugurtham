using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Repository.Profile.Raasi
{
    public interface IRaasi : IRepository<Mugurtham.DTO.Profile.Raasi>
    {
        IQueryable<Mugurtham.DTO.Profile.Raasi> GetByProfileID(string ProfileID);
    }
}

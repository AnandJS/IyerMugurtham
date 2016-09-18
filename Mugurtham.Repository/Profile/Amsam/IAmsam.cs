using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Repository.Profile.Amsam
{
    public interface IAmsam : IRepository<Mugurtham.DTO.Profile.Amsam>
    {
        IQueryable<Mugurtham.DTO.Profile.Amsam> GetByProfileID(string ProfileID);
    }
}

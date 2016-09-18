using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Repository.Profile.Reference
{
    public interface IReference : IRepository<Mugurtham.DTO.Profile.Reference>
    {
        IQueryable<Mugurtham.DTO.Profile.Reference> GetContactNumber(string ProfileID);
    }
}

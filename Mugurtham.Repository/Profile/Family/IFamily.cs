using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Repository.Profile.Family
{
    public interface IFamily : IRepository<Mugurtham.DTO.Profile.Family>
    {
        IQueryable<Mugurtham.DTO.Profile.Family> GetFamilyType(string ProfileID);
    }
}

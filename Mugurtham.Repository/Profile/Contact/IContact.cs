using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Repository.Profile.Contact
{
    public interface IContact : IRepository<Mugurtham.DTO.Profile.Contact>
    {
        IQueryable<Mugurtham.DTO.Profile.Contact> GetEmail(string ProfileID);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Mugurtham.Repository.Profile.Contact
{
    /// <summary>
    /// This class is used for implementaion of the IContact interface only
    /// </summary>
    public class Contact : GenericRepository<Mugurtham.DTO.Profile.Contact>, IContact
    {
        public Contact(DbContext objDbContext)
            : base(objDbContext)
        {
        }

        public IQueryable<Mugurtham.DTO.Profile.Contact> GetEmail(string ID)
        {
            return GetAll().Where(p => p.ProfileID == ID);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Mugurtham.Repository.User
{
    /// <summary>
    /// This class is used for implementaion of the IUser interface only
    /// </summary>
    public class User : GenericRepository<Mugurtham.DTO.User.User>, IUser
    {
        public User(DbContext objDbContext)
            : base(objDbContext)
        {
        }

        public IQueryable<Mugurtham.DTO.User.User> GetUserName(string ID)
        {
            return GetAll().Where(p => p.ID == ID);
        }
    }
}

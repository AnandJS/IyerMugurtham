using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Repository.User
{
    public interface IUser : IRepository<Mugurtham.DTO.User.User>
    {
        IQueryable<Mugurtham.DTO.User.User> GetUserName(string ID);
    }
}

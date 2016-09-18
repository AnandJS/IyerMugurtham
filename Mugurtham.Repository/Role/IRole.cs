using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Repository.Role
{
    public interface IRole : IRepository<Mugurtham.DTO.Role.Role>
    {
        IQueryable<Mugurtham.DTO.Role.Role> GetRoleByID(string ID);
    }
}

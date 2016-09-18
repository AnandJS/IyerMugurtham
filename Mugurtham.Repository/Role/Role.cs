using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Mugurtham.Repository.Role
{
    /// <summary>
    /// This class is used for implementaion of the IRole interface only
    /// </summary>
    public class Role : GenericRepository<Mugurtham.DTO.Role.Role>, IRole
    {
        public Role(DbContext objDbContext)
            : base(objDbContext)
        {
        }

        public IQueryable<Mugurtham.DTO.Role.Role> GetRoleByID(string ID)
        {
            return GetAll().Where(p => p.ID == ID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Repository.Sangam
{
    public interface ISangam : IRepository<Mugurtham.DTO.Sangam.Sangam>
    {
        IQueryable<Mugurtham.DTO.Sangam.Sangam> GetSangamName(string ID);
    }
}

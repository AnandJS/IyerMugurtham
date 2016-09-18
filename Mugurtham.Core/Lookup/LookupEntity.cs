using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Core.Lookup
{
    public class LookupEntity
    {

        public List<Mugurtham.Core.Sangam.SangamCoreEntity> SangamCoreEntity { get; set; }
        public List<Mugurtham.Core.Role.RoleCoreEntity> RoleCoreEntity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Core.ProfileInterested
{
    public class ProfileInterestedCoreEntity
    {
        public DateTime? InterestedDate { get; set; }
        public string ID { get; set; }
        public string ViewerID { get; set; }
        public string InterestedInID { get; set; }
    }
}

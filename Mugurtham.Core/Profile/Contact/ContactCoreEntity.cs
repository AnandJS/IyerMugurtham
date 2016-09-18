using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Core.Contact
{
    public class ContactCoreEntity
    {
        public string ProfileID { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string LandlineNumber { get; set; }
        public string ResidentialAddress { get; set; }
        public string Relationship { get; set; }
        public string TimeToCall { get; set; }
    }
}

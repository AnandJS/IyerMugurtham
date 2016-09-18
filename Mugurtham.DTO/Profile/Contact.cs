using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mugurtham.DTO.Profile
{
    [Table("ProfileContact")]
    public class Contact
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Key]
        public string ProfileID { get; set; }
        public string EMail { get; set; }
        public string MobileNumber { get; set; }
        public string LandLineNumber { get; set; }
        public string Address { get; set; }
        public string RelationShipWithMember { get; set; }
        public string ConvinientTimeToCall { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }


    }
}

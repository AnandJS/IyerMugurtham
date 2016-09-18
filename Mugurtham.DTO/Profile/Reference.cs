using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mugurtham.DTO.Profile
{
    [Table("ProfileReference")]
    public class Reference
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Key]
        public string ProfileID { get; set; }
        public string NomineeName { get; set; }
        public string ContactNo { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mugurtham.DTO.Profile
{
    [Table("ProfileCareer")]
    public class Career
    {
        public decimal Income { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Key]
        public string ProfileID { get; set; }
        public string Education { get; set; }
        public string EducationInDetail { get; set; }
        public string EmployedIn { get; set; }
        public string Occupation { get; set; }
        public string OccupationInDetail { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}

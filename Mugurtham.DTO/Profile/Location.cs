using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mugurtham.DTO.Profile
{
    [Table("ProfileLocation")]
    public class Location
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Key]
        public string ProfileID { get; set; }
        public string CountryLivingIn { get; set; }
        public string CitizenShip { get; set; }
        public string ResidentStatus { get; set; }
        public string ResidingState { get; set; }
        public string ResidingCity { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mugurtham.DTO.Profile
{
    [Table("ProfileRaasi")]
    public class Raasi
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Key]
        public string ProfileID { get; set; }
        public string Kattam1 { get; set; }
        public string Kattam2 { get; set; }
        public string Kattam3 { get; set; }
        public string Kattam4 { get; set; }
        public string Kattam5 { get; set; }
        public string Kattam6 { get; set; }
        public string Kattam7 { get; set; }
        public string Kattam8 { get; set; }
        public string Kattam9 { get; set; }
        public string Kattam10 { get; set; }
        public string Kattam11 { get; set; }
        public string Kattam12 { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}

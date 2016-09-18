using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mugurtham.DTO.Sangam
{
    [Table("SangamMaster")]
    public class Sangam
    {
        public Decimal? RunningNoStartsFrom { get; set; }
        public Decimal? LastProfileIDNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string ProfileIDStartsWith { get; set; }
        public string AboutSangam { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string IsActivated { get; set; }
        public string LogoPath { get; set; }
        public string BannerPath { get; set; }     

    }
}

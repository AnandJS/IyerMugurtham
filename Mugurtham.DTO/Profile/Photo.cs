using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mugurtham.DTO.Profile
{
    [Table("ProfilePhoto")]
    public class Photo
    {
        public Decimal? IsProfilePic { get; set; }
        [Key]
        public string ID { get; set; }
        public string ProfileID { get; set; }
        public string PhotoPath { get; set; }
    }
}


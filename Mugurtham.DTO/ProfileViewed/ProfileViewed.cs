using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mugurtham.DTO.ProfileViewed
{
    [Table("ProfileViewed")]
    public class ProfileViewed
    {
        [Key]
        public string ID { get; set; }
        public string ViewerID { get; set; }
        public string ViewedID { get; set; }
    }
}

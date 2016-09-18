using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mugurtham.DTO.User
{
    [Table("PortalUser")]
    public class User
    {
        public Decimal? IsHighlighted { get; set; }
        public Decimal? ShowHoroscope { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string SangamID { get; set; }
        public string RoleID { get; set; }
        public string ThemeID { get; set; }
        public string LocaleID { get; set; }
        public string IsActivated { get; set; }
        public string HomePagePath { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}

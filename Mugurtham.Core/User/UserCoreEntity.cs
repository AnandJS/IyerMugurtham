using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Core.User
{
    public class UserCoreEntity
    {
        public Decimal? IsHighlighted { get; set; }
        public Decimal? ShowHoroscope { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        
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
        //The below property is used only for Login Validation,
        //must not be used for other purpose please
        public string LoginStatus { get; set; }
        public string SangamName { get; set; }

    }
}

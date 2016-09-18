using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Core.Profile.Photo
{
    public class PhotoCoreEntity
    {
        public Decimal? IsProfilePic { get; set; }
        public string ID { get; set; }
        public string ProfileID { get; set; }
        public string PhotoPath { get; set; }
    }
}

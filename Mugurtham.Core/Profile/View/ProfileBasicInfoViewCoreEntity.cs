using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.Core.Profile.Photo;

namespace Mugurtham.Core.Profile.View
{
    public class ProfileBasicInfoViewCoreEntity
    {
        public decimal? Age { get; set; }

        public string MugurthamProfileID { get; set; }
        public string SangamProfileID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Education { get; set; }
        public string Location { get; set; }
        public string Occupation { get; set; }
        public string SangamID { get; set; }
        public string SangamName { get; set; }
        public string SubCaste { get; set; }
        public string Star { get; set; }
        public string AboutMe { get; set; }
        public List<PhotoCoreEntity> objPhotoCoreEntityList { get; set; }
    }
}

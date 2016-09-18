using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.Core.Profile.Photo;

namespace Mugurtham.Core.Profile.View
{
    public class ProfileBasicViewEntity
    {
        public List<ProfileBasicInfoViewCoreEntity> ProfileBasicInfoViewCoreEntityList { get; set; }
        public List<PhotoCoreEntity> PhotoCoreEntityList { get; set; }
    }
}

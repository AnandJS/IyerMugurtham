using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Core.Sangam
{
    public class SangamCoreEntity
    {
        public Decimal? RunningNoStartsFrom { get; set; }
        public Decimal? LastProfileIDNo { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string ProfileIDStartsWith { get; set; }
        public string AboutSangam { get; set; }
        public string IsActivated { get; set; }
        public string LogoPath { get; set; }
        public string BannerPath { get; set; }     

    }
}

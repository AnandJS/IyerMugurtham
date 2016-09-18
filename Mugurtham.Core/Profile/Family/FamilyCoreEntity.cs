using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Core.Family
{
    public class FamilyCoreEntity
    {
        public Decimal? NoOfBrothers { get; set; }
        public Decimal? MarriedBrothers { get; set; }
        public Decimal? NoOfSisters { get; set; }
        public Decimal? MarriedSisters { get; set; }

        public string FamilyID { get; set; }
        public string ProfileID { get; set; }
        public string FamilyValue { get; set; }
        public string FamilType { get; set; }
        public string FamilyStatus { get; set; }
        public string FathersName { get; set; }
        public string Mothersname { get; set; }
        public string FathersOccupation { get; set; }
        public string MothersOccupation { get; set; }
        public string FamilyOrigin { get; set; }
        public string AboutFamily { get; set; }
    }
}

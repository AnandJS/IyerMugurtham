using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mugurtham.DTO.Profile
{
    [Table("ProfileFamily")]
    public class Family
    {
        public Decimal? NoOfBrothers { get; set; }
        public Decimal? BrothersMarried { get; set; }
        public Decimal? NoOfSisters { get; set; }
        public Decimal? SistersMarried { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [Key]
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
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}

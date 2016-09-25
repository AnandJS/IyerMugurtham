using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mugurtham.DTO.Profile
{
    [Table("ProfileBasicInfo")]
    public class BasicInfo
    {
        public Decimal? Age { get; set; }
        public Decimal? NoOfChildren { get; set; }
        public Decimal? Weight { get; set; }
        public Decimal? ZodiacYear { get; set; }
        public Decimal? ZodiacMonth { get; set; }
        public Decimal? ZodiacDay { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public DateTime? TamilDOB { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }        

        public string ElanUserID { get; set; }
        [Key]
        public string ProfileID { get; set; }
        public string SangamProfileID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TimeOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string ChildrenLivingStatus { get; set; }
        public string Height { get; set; }
        public string BodyType { get; set; }
        public string Complexion { get; set; }
        public string PhysicalStatus { get; set; }
        public string BloodGroup { get; set; }
        public string MotherTongue { get; set; }
        public string ProfileCreatedBy { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string SubCaste { get; set; }
        public string Gothram { get; set; }
        public string Star { get; set; }
        public string Raasi { get; set; }
        public string Zodiac { get; set; }
        public string HoroscopeMatch { get; set; }
        public string AnyDosham { get; set; }
        public string Eating { get; set; }
        public string Smoking { get; set; }
        public string Drinking { get; set; }
        public string AboutMe { get; set; }
        public string PartnerExpectations { get; set; }
        public string CreatedBy { get; set; }
        public string SangamID { get; set; }
        public string ModifiedBy { get; set; }
        public string PhotoPath { get; set; }
        public string Paadham { get; set; }
    }
}

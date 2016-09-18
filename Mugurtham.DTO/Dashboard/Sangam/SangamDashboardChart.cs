using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mugurtham.DTO.Dashboard.Sangam
{
    [Table("SangamDashboardChart")]
    public class SangamDashboardChart
    {
        public decimal? Count { get; set; }
        [Key]
        public string ID { get; set; }
        public string Month { get; set; }
        public string SangamID { get; set; }
    }
}

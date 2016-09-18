using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.DTO.Dashboard.Sangam;

namespace Mugurtham.Repository.Dashboard.Sangam
{
    public interface IDashboard
    {
        List<Mugurtham.DTO.Dashboard.Sangam.SangamDashboardChart> getSangamDashboardChartData(string strSangamID);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Mugurtham.Repository.Dashboard.Sangam
{
    public class Dashboard : GenericRepository<Mugurtham.DTO.Dashboard.Sangam.SangamDashboardChart>, IDashboard
    {
        Mugurtham.DAL.MugurthamDBContext objMugurthamDBContext = null;
        public Dashboard(Mugurtham.DAL.MugurthamDBContext objDbContext)
            : base(objDbContext)
        {
            objMugurthamDBContext = objDbContext;
        }

        public List<Mugurtham.DTO.Dashboard.Sangam.SangamDashboardChart> getSangamDashboardChartData(string strSangamID)
        {
            var paramGender = new System.Data.SqlClient.SqlParameter
            {
                ParameterName = "@SangamID",
                Value = strSangamID
            };
            var objBasicInfo = objMugurthamDBContext.Database.SqlQuery<Mugurtham.DTO.Dashboard.Sangam.SangamDashboardChart>(
           "exec uspGetYearlySalesReport  @SangamID", paramGender).ToList<Mugurtham.DTO.Dashboard.Sangam.SangamDashboardChart>();
            return objBasicInfo;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.UOW;
using Mugurtham.Common.Utilities;

namespace Mugurtham.Core.Dashboard.Sangam
{
    public class SangamDashboardCore
    {
        public List<SangamDashboardCoreEntity> GetAll(string strSangamID)
        {
            List<SangamDashboardCoreEntity> objListSangamDashboardCoreEntity = new List<SangamDashboardCoreEntity>();
            try
            {
                List<Mugurtham.DTO.Dashboard.Sangam.SangamDashboardChart> objListSangamDashboardChart = new List<Mugurtham.DTO.Dashboard.Sangam.SangamDashboardChart>();
                IUnitOfWork objUOW = new UnitOfWork();
                using (objUOW as IDisposable)
                    objListSangamDashboardChart = objUOW.RepositorySangamDashboardChart.getSangamDashboardChartData(strSangamID).ToList();
                objUOW = null;
                if (objListSangamDashboardChart != null && objListSangamDashboardChart.Count > 0)
                {
                    foreach (Mugurtham.DTO.Dashboard.Sangam.SangamDashboardChart objSangamDashboardChart in objListSangamDashboardChart)
                    {
                        using (objSangamDashboardChart as IDisposable)
                        {
                            SangamDashboardCoreEntity objSangamDashboardCoreEntity = new SangamDashboardCoreEntity();
                            objSangamDashboardCoreEntity.ID = objSangamDashboardChart.ID;
                            objSangamDashboardCoreEntity.Count = objSangamDashboardChart.Count;
                            objSangamDashboardCoreEntity.Month = objSangamDashboardChart.Month;
                            objSangamDashboardCoreEntity.SangamID = objSangamDashboardChart.SangamID;
                            objListSangamDashboardCoreEntity.Add(objSangamDashboardCoreEntity);
                            objSangamDashboardCoreEntity = null;
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return objListSangamDashboardCoreEntity;
        }
    }
}

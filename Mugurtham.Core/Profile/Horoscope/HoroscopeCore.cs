using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.UOW;
using Mugurtham.Core.Raasi;
using Mugurtham.Core.Amsam;
using Mugurtham.Common.Utilities;

namespace Mugurtham.Core.Profile.Horoscope
{
    public class HoroscopeCore
    {
        public int Edit(ref HoroscopeCoreEntity objHoroscopeCoreEntity)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    // Save Data to Raasi
                    RaasiCoreEntity objRaasiCoreEntity = new RaasiCoreEntity();
                    using (objRaasiCoreEntity as IDisposable)
                    {
                        objRaasiCoreEntity.ProfileID = objHoroscopeCoreEntity.ProfileID;
                        objRaasiCoreEntity.Kattam1 = objHoroscopeCoreEntity.RaasiKattam1;
                        objRaasiCoreEntity.Kattam2 = objHoroscopeCoreEntity.RaasiKattam2;
                        objRaasiCoreEntity.Kattam3 = objHoroscopeCoreEntity.RaasiKattam3;
                        objRaasiCoreEntity.Kattam4 = objHoroscopeCoreEntity.RaasiKattam4;
                        objRaasiCoreEntity.Kattam5 = objHoroscopeCoreEntity.RaasiKattam5;
                        objRaasiCoreEntity.Kattam6 = objHoroscopeCoreEntity.RaasiKattam6;
                        objRaasiCoreEntity.Kattam7 = objHoroscopeCoreEntity.RaasiKattam7;
                        objRaasiCoreEntity.Kattam8 = objHoroscopeCoreEntity.RaasiKattam8;
                        objRaasiCoreEntity.Kattam9 = objHoroscopeCoreEntity.RaasiKattam9;
                        objRaasiCoreEntity.Kattam10 = objHoroscopeCoreEntity.RaasiKattam10;
                        objRaasiCoreEntity.Kattam11 = objHoroscopeCoreEntity.RaasiKattam11;
                        objRaasiCoreEntity.Kattam12 = objHoroscopeCoreEntity.RaasiKattam12;
                        Mugurtham.DTO.Profile.Raasi objDTORaasi = new DTO.Profile.Raasi();
                        using (objDTORaasi as IDisposable)
                        {
                            RaasiCore objRaasiCore = new RaasiCore();
                            using (objRaasiCore as IDisposable)
                                objRaasiCore.AssignDTOFromEntity(ref objDTORaasi, ref objRaasiCoreEntity);
                            objRaasiCore = null;
                        }
                        objIUnitOfWork.RepositoryRaasi.Edit(objDTORaasi);
                        objDTORaasi = null;
                    }
                    objRaasiCoreEntity = null;
                    // Save data to Amsam
                    AmsamCoreEntity objAmsamCoreEntity = new AmsamCoreEntity();
                    using (objAmsamCoreEntity as IDisposable)
                    {
                        objAmsamCoreEntity.ProfileID = objHoroscopeCoreEntity.ProfileID;
                        objAmsamCoreEntity.Kattam1 = objHoroscopeCoreEntity.AmsamKattam1;
                        objAmsamCoreEntity.Kattam2 = objHoroscopeCoreEntity.AmsamKattam2;
                        objAmsamCoreEntity.Kattam3 = objHoroscopeCoreEntity.AmsamKattam3;
                        objAmsamCoreEntity.Kattam4 = objHoroscopeCoreEntity.AmsamKattam4;
                        objAmsamCoreEntity.Kattam5 = objHoroscopeCoreEntity.AmsamKattam5;
                        objAmsamCoreEntity.Kattam6 = objHoroscopeCoreEntity.AmsamKattam6;
                        objAmsamCoreEntity.Kattam7 = objHoroscopeCoreEntity.AmsamKattam7;
                        objAmsamCoreEntity.Kattam8 = objHoroscopeCoreEntity.AmsamKattam8;
                        objAmsamCoreEntity.Kattam9 = objHoroscopeCoreEntity.AmsamKattam9;
                        objAmsamCoreEntity.Kattam10 = objHoroscopeCoreEntity.AmsamKattam10;
                        objAmsamCoreEntity.Kattam11 = objHoroscopeCoreEntity.AmsamKattam11;
                        objAmsamCoreEntity.Kattam12 = objHoroscopeCoreEntity.AmsamKattam12;
                        Mugurtham.DTO.Profile.Amsam objDTOAmsam = new DTO.Profile.Amsam();
                        using (objDTOAmsam as IDisposable)
                        {
                            AmsamCore objAmsamCore = new AmsamCore();
                            using (objAmsamCore as IDisposable)
                                objAmsamCore.AssignDTOFromEntity(ref objDTOAmsam, ref objAmsamCoreEntity);
                            objAmsamCore = null;
                        }
                        objIUnitOfWork.RepositoryAmsam.Edit(objDTOAmsam);
                        objDTOAmsam = null;
                    }
                    objAmsamCoreEntity = null;
                }
                objIUnitOfWork.commit();
                objIUnitOfWork = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        public HoroscopeCoreEntity GetByProfileID(string strProfileID)
        {
            HoroscopeCoreEntity objHoroscopeCoreEntity = new HoroscopeCoreEntity();
            try
            {
                Mugurtham.DTO.Profile.Raasi objRaasi = new Mugurtham.DTO.Profile.Raasi();
                Mugurtham.DTO.Profile.Amsam objAmsam = new Mugurtham.DTO.Profile.Amsam();
                IUnitOfWork objUOW = new UnitOfWork();
                using (objUOW as IDisposable)
                {
                    objRaasi = objUOW.RepositoryRaasi.GetAll().ToList().Where(p => p.ProfileID.Trim().ToLower() == strProfileID.Trim().ToLower()).FirstOrDefault();
                    objAmsam = objUOW.RepositoryAmsam.GetAll().ToList().Where(p => p.ProfileID.Trim().ToLower() == strProfileID.Trim().ToLower()).FirstOrDefault();
                }
                objUOW = null;
                //Getting Raasi Data
                if (objRaasi != null)
                {
                    using (objRaasi as IDisposable)
                    {
                        RaasiCoreEntity objRaasiCoreEntity = new RaasiCoreEntity();
                        using (objRaasiCoreEntity as IDisposable)
                        {
                            RaasiCore objRaasiCore = new RaasiCore();
                            using (objRaasiCore as IDisposable)
                                objRaasiCore.AssignEntityFromDTO(ref objRaasi, ref objRaasiCoreEntity);
                            objRaasiCore = null;
                        }
                        objHoroscopeCoreEntity.ProfileID = objRaasiCoreEntity.ProfileID;
                        objHoroscopeCoreEntity.RaasiKattam1 = objRaasiCoreEntity.Kattam1;
                        objHoroscopeCoreEntity.RaasiKattam2 = objRaasiCoreEntity.Kattam2;
                        objHoroscopeCoreEntity.RaasiKattam3 = objRaasiCoreEntity.Kattam3;
                        objHoroscopeCoreEntity.RaasiKattam4 = objRaasiCoreEntity.Kattam4;
                        objHoroscopeCoreEntity.RaasiKattam5 = objRaasiCoreEntity.Kattam5;
                        objHoroscopeCoreEntity.RaasiKattam6 = objRaasiCoreEntity.Kattam6;
                        objHoroscopeCoreEntity.RaasiKattam7 = objRaasiCoreEntity.Kattam7;
                        objHoroscopeCoreEntity.RaasiKattam8 = objRaasiCoreEntity.Kattam8;
                        objHoroscopeCoreEntity.RaasiKattam9 = objRaasiCoreEntity.Kattam9;
                        objHoroscopeCoreEntity.RaasiKattam10 = objRaasiCoreEntity.Kattam10;
                        objHoroscopeCoreEntity.RaasiKattam11 = objRaasiCoreEntity.Kattam11;
                        objHoroscopeCoreEntity.RaasiKattam12 = objRaasiCoreEntity.Kattam12;
                        objRaasiCoreEntity = null;
                    }
                }
                objRaasi = null;
                // Getting Amsam Data
                if (objAmsam != null)
                {
                    using (objAmsam as IDisposable)
                    {
                        AmsamCoreEntity objAmsamCoreEntity = new AmsamCoreEntity();
                        using (objAmsamCoreEntity as IDisposable)
                        {
                            AmsamCore objAmsamCore = new AmsamCore();
                            using (objAmsamCore as IDisposable)
                                objAmsamCore.AssignEntityFromDTO(ref objAmsam, ref objAmsamCoreEntity);
                            objAmsamCore = null;
                        }
                        objHoroscopeCoreEntity.ProfileID = objAmsamCoreEntity.ProfileID;
                        objHoroscopeCoreEntity.AmsamKattam1 = objAmsamCoreEntity.Kattam1;
                        objHoroscopeCoreEntity.AmsamKattam2 = objAmsamCoreEntity.Kattam2;
                        objHoroscopeCoreEntity.AmsamKattam3 = objAmsamCoreEntity.Kattam3;
                        objHoroscopeCoreEntity.AmsamKattam4 = objAmsamCoreEntity.Kattam4;
                        objHoroscopeCoreEntity.AmsamKattam5 = objAmsamCoreEntity.Kattam5;
                        objHoroscopeCoreEntity.AmsamKattam6 = objAmsamCoreEntity.Kattam6;
                        objHoroscopeCoreEntity.AmsamKattam7 = objAmsamCoreEntity.Kattam7;
                        objHoroscopeCoreEntity.AmsamKattam8 = objAmsamCoreEntity.Kattam8;
                        objHoroscopeCoreEntity.AmsamKattam9 = objAmsamCoreEntity.Kattam9;
                        objHoroscopeCoreEntity.AmsamKattam10 = objAmsamCoreEntity.Kattam10;
                        objHoroscopeCoreEntity.AmsamKattam11 = objAmsamCoreEntity.Kattam11;
                        objHoroscopeCoreEntity.AmsamKattam12 = objAmsamCoreEntity.Kattam12;
                        objAmsamCoreEntity = null;
                    }
                }
                objAmsam = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return objHoroscopeCoreEntity;
        }
    }
}

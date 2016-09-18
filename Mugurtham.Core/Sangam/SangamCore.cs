using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.UOW;
using Mugurtham.Common.Utilities;

namespace Mugurtham.Core.Sangam
{
    public class SangamCore
    {
        public int Add(ref Mugurtham.Core.Sangam.SangamCoreEntity objSangamCoreEntity, out string strSangamID)
        {
            strSangamID = Helpers.primaryKey;
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.Sangam.Sangam objDTOSangam = new DTO.Sangam.Sangam();
                    using (objDTOSangam as IDisposable)
                    {
                        objSangamCoreEntity.ID = strSangamID;
                        objSangamCoreEntity.RunningNoStartsFrom = 1000;
                        objSangamCoreEntity.LastProfileIDNo = 1000;
                        AssignDTOFromEntity(ref objDTOSangam, ref objSangamCoreEntity);
                    }
                    objIUnitOfWork.RepositorySangam.Add(objDTOSangam);
                    objDTOSangam = null;
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

        public int Edit(ref Mugurtham.Core.Sangam.SangamCoreEntity objSangamCoreEntity)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.Sangam.Sangam objDTOSangam = new DTO.Sangam.Sangam();
                    using (objDTOSangam as IDisposable)
                    {
                        AssignDTOFromEntity(ref objDTOSangam, ref objSangamCoreEntity);
                    }
                    objIUnitOfWork.RepositorySangam.Edit(objDTOSangam);
                    objDTOSangam = null;
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

        public SangamCoreEntity GetByID(string strID)
        {
            SangamCoreEntity objSangamCoreEntity = new SangamCoreEntity();
            try
            {
                Mugurtham.DTO.Sangam.Sangam objSangam = new Mugurtham.DTO.Sangam.Sangam();
                IUnitOfWork objUOW = new UnitOfWork();
                using (objUOW as IDisposable)
                    objSangam = objUOW.RepositorySangam.GetAll().ToList().Where(p => p.ID.Trim().ToLower() == strID.Trim().ToLower()).FirstOrDefault();
                objUOW = null;
                if (objSangam != null)
                {
                    using (objSangam as IDisposable)
                    {
                        AssignEntityFromDTO(ref objSangam, ref objSangamCoreEntity);
                    }
                }
                objSangam = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return objSangamCoreEntity;
        }

        public int GetAll(ref List<SangamCoreEntity> objSangamCoreEntityList)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    foreach (Mugurtham.DTO.Sangam.Sangam objSangam in objIUnitOfWork.RepositorySangam.GetAll().Where(p => p.IsActivated == "1").ToList().OrderBy(x => x.Name))
                    {
                        Mugurtham.DTO.Sangam.Sangam _objSangam = objSangam;
                        using (_objSangam as IDisposable)
                        {
                            SangamCoreEntity objSangamCoreEntity = new SangamCoreEntity();
                            using (objSangamCoreEntity as IDisposable)
                            {
                                AssignEntityFromDTO(ref _objSangam, ref objSangamCoreEntity);
                                objSangamCoreEntityList.Add(objSangamCoreEntity);
                            }
                            objSangamCoreEntity = null;
                        }
                        _objSangam = null;
                    }
                }
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        public int GetAllWithoutRestrictions(ref List<SangamCoreEntity> objSangamCoreEntityList)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    foreach (Mugurtham.DTO.Sangam.Sangam objSangam in objIUnitOfWork.RepositorySangam.GetAll().ToList())
                    {
                        Mugurtham.DTO.Sangam.Sangam _objSangam = objSangam;
                        using (_objSangam as IDisposable)
                        {
                            SangamCoreEntity objSangamCoreEntity = new SangamCoreEntity();
                            using (objSangamCoreEntity as IDisposable)
                            {
                                AssignEntityFromDTO(ref _objSangam, ref objSangamCoreEntity);
                                objSangamCoreEntityList.Add(objSangamCoreEntity);
                            }
                            objSangamCoreEntity = null;
                        }
                        _objSangam = null;
                    }
                }
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }

        public int GetNewProfileID(out string strNewProfileID, Mugurtham.Core.Login.LoggedInUser objLoggedIn)
        {
            strNewProfileID = string.Empty;
            try
            {
                if (!string.IsNullOrWhiteSpace(objLoggedIn.sangamID))
                {
                    SangamCoreEntity objSangamCoreEntity = new SangamCoreEntity();
                    using (objSangamCoreEntity as IDisposable)
                    {
                        objSangamCoreEntity = GetByID(objLoggedIn.sangamID);
                        strNewProfileID = objSangamCoreEntity.ProfileIDStartsWith + (objSangamCoreEntity.LastProfileIDNo + 1).ToString();
                    }
                }
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }

        private int AssignDTOFromEntity(ref Mugurtham.DTO.Sangam.Sangam objDTOSangam, ref Mugurtham.Core.Sangam.SangamCoreEntity objSangamCoreEntity)
        {
            try
            {
                objDTOSangam.AboutSangam = objSangamCoreEntity.AboutSangam;
                objDTOSangam.Address = objSangamCoreEntity.Address;
                objDTOSangam.ContactNumber = objSangamCoreEntity.ContactNumber;
                objDTOSangam.CreatedDate = DateTime.Now;
                objDTOSangam.ID = objSangamCoreEntity.ID;
                objDTOSangam.ModifiedDate = DateTime.Now;
                objDTOSangam.Name = objSangamCoreEntity.Name;
                objDTOSangam.ProfileIDStartsWith = objSangamCoreEntity.ProfileIDStartsWith;
                objDTOSangam.IsActivated = objSangamCoreEntity.IsActivated;
                objDTOSangam.LogoPath = objSangamCoreEntity.LogoPath;
                objDTOSangam.BannerPath = objSangamCoreEntity.BannerPath;
                objDTOSangam.RunningNoStartsFrom = objSangamCoreEntity.RunningNoStartsFrom;
                objDTOSangam.LastProfileIDNo = objSangamCoreEntity.LastProfileIDNo;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }

        private int AssignEntityFromDTO(ref Mugurtham.DTO.Sangam.Sangam objDTOSangam, ref Mugurtham.Core.Sangam.SangamCoreEntity objSangamCoreEntity)
        {
            try
            {
                objSangamCoreEntity.AboutSangam = objDTOSangam.AboutSangam;
                objSangamCoreEntity.Address = objDTOSangam.Address;
                objSangamCoreEntity.ContactNumber = objDTOSangam.ContactNumber;
                objSangamCoreEntity.ID = objDTOSangam.ID;
                objSangamCoreEntity.Name = objDTOSangam.Name;
                objSangamCoreEntity.ProfileIDStartsWith = objDTOSangam.ProfileIDStartsWith;
                objSangamCoreEntity.IsActivated = objDTOSangam.IsActivated;
                objSangamCoreEntity.LogoPath = objDTOSangam.LogoPath;
                objSangamCoreEntity.BannerPath = objDTOSangam.BannerPath;
                objSangamCoreEntity.RunningNoStartsFrom = objDTOSangam.RunningNoStartsFrom;
                objSangamCoreEntity.LastProfileIDNo = objDTOSangam.LastProfileIDNo;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
    }
}

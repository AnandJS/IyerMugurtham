using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.UOW;
using Mugurtham.Common.Utilities;

namespace Mugurtham.Core.Amsam
{
    public class AmsamCore
    {
        public int Add(ref Mugurtham.Core.Amsam.AmsamCoreEntity objAmsamCoreEntity)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.Profile.Amsam objDTOAmsam = new DTO.Profile.Amsam();
                    using (objDTOAmsam as IDisposable)
                    {
                        AssignDTOFromEntity(ref objDTOAmsam, ref objAmsamCoreEntity);
                    }
                    objIUnitOfWork.RepositoryAmsam.Add(objDTOAmsam);
                    objDTOAmsam = null;
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
        public int Edit(ref Mugurtham.Core.Amsam.AmsamCoreEntity objAmsamCoreEntity)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.Profile.Amsam objDTOAmsam = new DTO.Profile.Amsam();
                    using (objDTOAmsam as IDisposable)
                    {
                        AssignDTOFromEntity(ref objDTOAmsam, ref objAmsamCoreEntity);
                    }
                    objIUnitOfWork.RepositoryAmsam.Edit(objDTOAmsam);
                    objDTOAmsam = null;
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
        public AmsamCoreEntity GetByProfileID(string strProfileID)
        {
            AmsamCoreEntity objAmsamCoreEntity = new AmsamCoreEntity();
            try
            {
                Mugurtham.DTO.Profile.Amsam objAmsam = new Mugurtham.DTO.Profile.Amsam();
                IUnitOfWork objUOW = new UnitOfWork();
                using (objUOW as IDisposable)
                    objAmsam = objUOW.RepositoryAmsam.GetAll().ToList().Where(p => p.ProfileID.Trim().ToLower() == strProfileID.Trim().ToLower()).FirstOrDefault();
                objUOW = null;
                if (objAmsam != null)
                {
                    using (objAmsam as IDisposable)
                    {
                        AssignEntityFromDTO(ref objAmsam, ref objAmsamCoreEntity);
                    }
                }
                objAmsam = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return objAmsamCoreEntity;
        }
        public int AssignDTOFromEntity(ref Mugurtham.DTO.Profile.Amsam objDTOAmsam, ref Mugurtham.Core.Amsam.AmsamCoreEntity objAmsamCoreEntity)
        {
            try
            {
                objDTOAmsam.CreatedBy = objAmsamCoreEntity.CreatedBy;
                objDTOAmsam.Kattam1 = objAmsamCoreEntity.Kattam1;
                objDTOAmsam.Kattam2 = objAmsamCoreEntity.Kattam2;
                objDTOAmsam.Kattam3 = objAmsamCoreEntity.Kattam3;
                objDTOAmsam.Kattam4 = objAmsamCoreEntity.Kattam4;
                objDTOAmsam.Kattam5 = objAmsamCoreEntity.Kattam5;
                objDTOAmsam.Kattam6 = objAmsamCoreEntity.Kattam6;
                objDTOAmsam.Kattam7 = objAmsamCoreEntity.Kattam7;
                objDTOAmsam.Kattam8 = objAmsamCoreEntity.Kattam8;
                objDTOAmsam.Kattam9 = objAmsamCoreEntity.Kattam9;
                objDTOAmsam.Kattam10 = objAmsamCoreEntity.Kattam10;
                objDTOAmsam.Kattam11 = objAmsamCoreEntity.Kattam11;
                objDTOAmsam.Kattam12 = objAmsamCoreEntity.Kattam12;
                objDTOAmsam.CreatedDate = DateTime.Now;
                objDTOAmsam.ModifiedDate = DateTime.Now;
                objDTOAmsam.ProfileID = objAmsamCoreEntity.ProfileID;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        public int AssignEntityFromDTO(ref Mugurtham.DTO.Profile.Amsam objDTOAmsam, ref Mugurtham.Core.Amsam.AmsamCoreEntity objAmsamCoreEntity)
        {
            try
            {
                objAmsamCoreEntity.CreatedBy = objDTOAmsam.CreatedBy;
                objAmsamCoreEntity.Kattam1 = objDTOAmsam.Kattam1;
                objAmsamCoreEntity.Kattam2 = objDTOAmsam.Kattam2;
                objAmsamCoreEntity.Kattam3 = objDTOAmsam.Kattam3;
                objAmsamCoreEntity.Kattam4 = objDTOAmsam.Kattam4;
                objAmsamCoreEntity.Kattam5 = objDTOAmsam.Kattam5;
                objAmsamCoreEntity.Kattam6 = objDTOAmsam.Kattam6;
                objAmsamCoreEntity.Kattam7 = objDTOAmsam.Kattam7;
                objAmsamCoreEntity.Kattam8 = objDTOAmsam.Kattam8;
                objAmsamCoreEntity.Kattam9 = objDTOAmsam.Kattam9;
                objAmsamCoreEntity.Kattam10 = objDTOAmsam.Kattam10;
                objAmsamCoreEntity.Kattam11 = objDTOAmsam.Kattam11;
                objAmsamCoreEntity.Kattam12 = objDTOAmsam.Kattam12;
                objAmsamCoreEntity.CreatedDate = DateTime.Now;
                objAmsamCoreEntity.ModifiedDate = DateTime.Now;
                objAmsamCoreEntity.ProfileID = objDTOAmsam.ProfileID;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
    }
}

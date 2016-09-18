using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.UOW;
using Mugurtham.Common.Utilities;

namespace Mugurtham.Core.Career
{
    public class CareerCore
    {
        public int Add(ref Mugurtham.Core.Career.CareerCoreEntity objCareerCoreEntity)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.Profile.Career objDTOCareer = new DTO.Profile.Career();
                    using (objDTOCareer as IDisposable)
                    {
                        AssignDTOFromEntity(ref objDTOCareer, ref objCareerCoreEntity);
                    }
                    objIUnitOfWork.RepositoryCareer.Add(objDTOCareer);
                    objDTOCareer = null;
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

        public int Edit(ref Mugurtham.Core.Career.CareerCoreEntity objCareerCoreEntity)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.Profile.Career objDTOCareer = new DTO.Profile.Career();
                    using (objDTOCareer as IDisposable)
                    {
                        AssignDTOFromEntity(ref objDTOCareer, ref objCareerCoreEntity);
                    }
                    objIUnitOfWork.RepositoryCareer.Edit(objDTOCareer);
                    objDTOCareer = null;
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

        public CareerCoreEntity GetByProfileID(string strProfileID)
        {
            CareerCoreEntity objCareerCoreEntity = new CareerCoreEntity();
            try
            {
                Mugurtham.DTO.Profile.Career objCareer = new Mugurtham.DTO.Profile.Career();
                IUnitOfWork objUOW = new UnitOfWork();
                using (objUOW as IDisposable)
                    objCareer = objUOW.RepositoryCareer.GetAll().ToList().Where(p => p.ProfileID.Trim().ToLower() == strProfileID.Trim().ToLower()).FirstOrDefault();
                objUOW = null;
                if (objCareer != null)
                {
                    using (objCareer as IDisposable)
                    {
                        AssignEntityFromDTO(ref objCareerCoreEntity, objCareer);
                    }
                }
                objCareer = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return objCareerCoreEntity;
        }

        private int AssignDTOFromEntity(ref Mugurtham.DTO.Profile.Career objCareer, ref Mugurtham.Core.Career.CareerCoreEntity objCareerCoreEntity)
        {
            try
            {
                objCareer.Education = objCareerCoreEntity.Education;
                objCareer.EducationInDetail = objCareerCoreEntity.EducationInDetail;
                objCareer.EmployedIn = objCareerCoreEntity.EmployedIn;
                objCareer.Income = objCareerCoreEntity.AnnualIncome;
                objCareer.Occupation = objCareerCoreEntity.Occupation;
                objCareer.OccupationInDetail = objCareerCoreEntity.OccupationInDetail;
                objCareer.CreatedDate = DateTime.Now;
                objCareer.ModifiedDate = DateTime.Now;
                objCareer.ProfileID = objCareerCoreEntity.ProfileID;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }

        private int AssignEntityFromDTO(ref CareerCoreEntity objCareerCoreEntity, Mugurtham.DTO.Profile.Career objCareer)
        {
            try
            {
                objCareerCoreEntity.AnnualIncome = objCareer.Income;
                objCareerCoreEntity.Education = objCareer.Education;
                objCareerCoreEntity.EducationInDetail = objCareer.EducationInDetail;
                objCareerCoreEntity.EmployedIn = objCareer.EmployedIn;
                objCareerCoreEntity.Occupation = objCareer.Occupation;
                objCareerCoreEntity.OccupationInDetail = objCareer.OccupationInDetail;
                objCareerCoreEntity.ProfileID = objCareer.ProfileID;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
    }
}

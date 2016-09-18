using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.UOW;
using Mugurtham.Common.Utilities;

namespace Mugurtham.Core.Role
{
    public class RoleCore
    {
        public int Add(ref Mugurtham.Core.Role.RoleCoreEntity objRoleCoreEntity, out string strRoleID)
        {
            strRoleID = Helpers.primaryKey;
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.Role.Role objDTORole = new DTO.Role.Role();
                    using (objDTORole as IDisposable)
                    {
                        objRoleCoreEntity.ID = strRoleID;
                        AssignDTOFromEntity(ref objDTORole, ref objRoleCoreEntity);
                    }
                    objIUnitOfWork.RepositoryRole.Add(objDTORole);
                    objDTORole = null;
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

        public int Edit(ref Mugurtham.Core.Role.RoleCoreEntity objRoleCoreEntity)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.Role.Role objDTORole = new DTO.Role.Role();
                    using (objDTORole as IDisposable)
                    {
                        AssignDTOFromEntity(ref objDTORole, ref objRoleCoreEntity);
                    }
                    objIUnitOfWork.RepositoryRole.Edit(objDTORole);
                    objDTORole = null;
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

        public RoleCoreEntity GetByID(string strID)
        {
            RoleCoreEntity objRoleCoreEntity = new RoleCoreEntity();
            try
            {
                Mugurtham.DTO.Role.Role objSangam = new Mugurtham.DTO.Role.Role();
                IUnitOfWork objUOW = new UnitOfWork();
                using (objUOW as IDisposable)
                    objSangam = objUOW.RepositoryRole.GetAll().ToList().Where(p => p.ID.Trim().ToLower() == strID.Trim().ToLower()).FirstOrDefault();
                objUOW = null;
                if (objSangam != null)
                {
                    using (objSangam as IDisposable)
                    {
                        AssignEntityFromDTO(ref objSangam, ref objRoleCoreEntity);
                    }
                }
                objSangam = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return objRoleCoreEntity;
        }

        public int GetAll(ref List<RoleCoreEntity> objSangamCoreEntityList)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    foreach (Mugurtham.DTO.Role.Role objSangam in objIUnitOfWork.RepositoryRole.GetAll().ToList().OrderBy(x => x.Name))
                    {
                        Mugurtham.DTO.Role.Role _objSangam = objSangam;
                        using (_objSangam as IDisposable)
                        {
                            RoleCoreEntity objRoleCoreEntity = new RoleCoreEntity();
                            using (objRoleCoreEntity as IDisposable)
                            {
                                AssignEntityFromDTO(ref _objSangam, ref objRoleCoreEntity);
                                objSangamCoreEntityList.Add(objRoleCoreEntity);
                            }
                            objRoleCoreEntity = null;
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

        private int AssignDTOFromEntity(ref Mugurtham.DTO.Role.Role objDTORole, ref Mugurtham.Core.Role.RoleCoreEntity objRoleCoreEntity)
        {
            try
            {
                objDTORole.CreatedBy = objRoleCoreEntity.CreatedBy;
                objDTORole.CreatedDate = DateTime.Now;
                objDTORole.Description = objRoleCoreEntity.Description;
                objDTORole.ID = objRoleCoreEntity.ID;
                objDTORole.ModifiedBy = objRoleCoreEntity.ModifiedBy;
                objDTORole.ModifiedDate = DateTime.Now;
                objDTORole.Name = objRoleCoreEntity.Name;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }

        private int AssignEntityFromDTO(ref Mugurtham.DTO.Role.Role objDTORole, ref Mugurtham.Core.Role.RoleCoreEntity objRoleCoreEntity)
        {
            try
            {
                objRoleCoreEntity.CreatedBy = objDTORole.CreatedBy;
                objRoleCoreEntity.CreatedDate = DateTime.Now;
                objRoleCoreEntity.Description = objDTORole.Description;
                objRoleCoreEntity.ID = objDTORole.ID;
                objRoleCoreEntity.ModifiedBy = objDTORole.ModifiedBy;
                objRoleCoreEntity.ModifiedDate = DateTime.Now;
                objRoleCoreEntity.Name = objDTORole.Name;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
    }
}

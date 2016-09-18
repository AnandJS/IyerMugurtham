using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.UOW;
using Mugurtham.Common.Utilities;

namespace Mugurtham.Core.ProfileViewed
{
    public class ProfileViewedCore
    {
        public int Add(ref Mugurtham.Core.ProfileViewed.ProfileViewedCoreEntity objProfileViewedCoreEntity)
        {
            try
            {
                string strMappingID = string.Empty;
                string strViewerID = objProfileViewedCoreEntity.ViewerID;
                string strViewedID = objProfileViewedCoreEntity.ViewedID;
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.ProfileViewed.ProfileViewed objDTOProfileViewed = new DTO.ProfileViewed.ProfileViewed();
                    using (objDTOProfileViewed as IDisposable)
                    {
                        objDTOProfileViewed.ID = Helpers.primaryKey;
                        objDTOProfileViewed.ViewerID = objProfileViewedCoreEntity.ViewerID;
                        objDTOProfileViewed.ViewedID = objProfileViewedCoreEntity.ViewedID;
                    }
                    List<Mugurtham.DTO.ProfileViewed.ProfileViewed> objProfileViewed = new List<DTO.ProfileViewed.ProfileViewed>();
                    using (objProfileViewed as IDisposable)
                    {
                        objProfileViewed = objIUnitOfWork.RepositoryProfileViewed.GetAll().ToList().
                        Where(p => p.ViewerID.Trim().ToLower() == strViewerID.Trim().ToLower() &&
                              p.ViewedID.Trim().ToLower() == strViewedID.Trim().ToLower()).ToList();
                        foreach (DTO.ProfileViewed.ProfileViewed objProfiles in objProfileViewed)
                        {
                            strMappingID = objProfiles.ID;
                        }
                    }
                    if (objProfileViewed.Count == 0)
                    {
                        IUnitOfWork objIUnitOfWorkAdd = new UnitOfWork();
                        using (objIUnitOfWorkAdd as IDisposable)
                        {
                            objIUnitOfWorkAdd.RepositoryProfileViewed.Add(objDTOProfileViewed);
                            objIUnitOfWorkAdd.commit();
                            objDTOProfileViewed = null;
                        }
                        objIUnitOfWorkAdd = null;
                    }
                }
                objIUnitOfWork = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
    }
}


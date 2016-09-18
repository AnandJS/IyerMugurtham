using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.UOW;
using Mugurtham.Common.Utilities;

namespace Mugurtham.Core.Profile.Photo
{
    public class PhotoCore
    {
        public int Add(ref Mugurtham.Core.Profile.Photo.PhotoCoreEntity objPhotoCoreEntity)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.Profile.Photo objDTOPhoto = new DTO.Profile.Photo();
                    using (objDTOPhoto as IDisposable)
                    {
                        objDTOPhoto.ID = Helpers.primaryKey;
                        AssignDTOFromEntity(ref objDTOPhoto, ref objPhotoCoreEntity);
                    }
                    objIUnitOfWork.RepositoryPhoto.Add(objDTOPhoto);
                    objDTOPhoto = null;
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
        public int getProfilePhotos(string strProfileID, out IQueryable<DTO.Profile.Photo> objDTOPhotoList)
        {
            objDTOPhotoList = null;
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                    objDTOPhotoList = objIUnitOfWork.RepositoryPhoto.getProfilePhotos(strProfileID);
                objIUnitOfWork.commit();
                objIUnitOfWork = null;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        private int AssignDTOFromEntity(ref Mugurtham.DTO.Profile.Photo objPhoto, ref Mugurtham.Core.Profile.Photo.PhotoCoreEntity objPhotoCoreEntity)
        {
            try
            {
                objPhoto.ProfileID = objPhotoCoreEntity.ProfileID;
                objPhoto.PhotoPath = objPhotoCoreEntity.PhotoPath;
                objPhoto.IsProfilePic = objPhotoCoreEntity.IsProfilePic;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }

        private int AssignEntityFromDTO(ref PhotoCoreEntity objPhotoCoreEntity, Mugurtham.DTO.Profile.Photo objPhoto)
        {
            try
            {
                objPhotoCoreEntity.ProfileID = objPhoto.ProfileID;
                objPhotoCoreEntity.PhotoPath = objPhoto.PhotoPath;
                objPhotoCoreEntity.IsProfilePic = objPhoto.IsProfilePic;
            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
            return 0;
        }
        public int Delete(string strID)
        {
            try
            {
                IUnitOfWork objIUnitOfWork = new UnitOfWork();
                using (objIUnitOfWork as IDisposable)
                {
                    Mugurtham.DTO.Profile.Photo objPhoto = new DTO.Profile.Photo();
                    using (objPhoto as IDisposable)
                        objPhoto = objIUnitOfWork.RepositoryPhoto.GetAll().ToList().Where(p => p.ID == strID).FirstOrDefault();
                    if (objPhoto != null)
                    {
                        IUnitOfWork objIUnitOfWorkDeletePic = new UnitOfWork();
                        using (objIUnitOfWorkDeletePic as IDisposable)
                        {
                            objIUnitOfWorkDeletePic.RepositoryPhoto.Delete(objPhoto);
                            objIUnitOfWorkDeletePic.commit();
                        }
                        objIUnitOfWorkDeletePic = null;
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

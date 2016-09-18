using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Mugurtham.DAL;
using Mugurtham.Repository;

namespace Mugurtham.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool boolDisposeClosed = false;
        private MugurthamDBContext _DbContext { get; set; }

        private Mugurtham.Repository.Profile.BasicInfo.IBasicInfo _IBasicInfo;
        private Mugurtham.Repository.Profile.Career.ICareer _ICareer;
        private Mugurtham.Repository.Profile.Contact.IContact _IContact;
        private Mugurtham.Repository.Profile.Family.IFamily _IFamily;
        private Mugurtham.Repository.Profile.Location.ILocation _ILocation;
        private Mugurtham.Repository.Profile.Reference.IReference _IReference;
        private Mugurtham.Repository.Sangam.ISangam _ISangam;
        private Mugurtham.Repository.Role.IRole _IRole;
        private Mugurtham.Repository.User.IUser _IUser;
        private Mugurtham.Repository.Profile.Raasi.IRaasi _IRaasi;
        private Mugurtham.Repository.Profile.Amsam.IAmsam _IAmsam;
        private Mugurtham.Repository.Dashboard.Sangam.IDashboard _ISangamDahboardChart;
        private Mugurtham.Repository.ProfileViewed.IProfileViewed _IProfileViewed;
        private Mugurtham.Repository.ProfileInterested.IProfileInterested _IProfileInterested;
        private Mugurtham.Repository.Profile.Photo.IPhoto _IPhoto;

        public UnitOfWork()
        {
            CreateDbContext();
        }

        public void commit()
        {
            _DbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            _DbContext = new MugurthamDBContext();

            // Do NOT enable proxied entities, else serialization fails.
            //if false it will not get the associated certification and skills when we
            //get the applicants
            _DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            _DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            _DbContext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }

        public Mugurtham.Repository.Profile.BasicInfo.IBasicInfo RepositoryBasicInfo
        {
            get
            {
                if (_IBasicInfo == null)
                {
                    _IBasicInfo = new Mugurtham.Repository.Profile.BasicInfo.BasicInfo(_DbContext);
                }
                return _IBasicInfo;
            }
        }

        public Mugurtham.Repository.Profile.Career.ICareer RepositoryCareer
        {
            get
            {
                if (_ICareer == null)
                {
                    _ICareer = new Mugurtham.Repository.Profile.Career.Career(_DbContext);
                }
                return _ICareer;
            }
        }

        public Mugurtham.Repository.Profile.Contact.IContact RepositoryContact
        {
            get
            {
                if (_IContact == null)
                {
                    _IContact = new Mugurtham.Repository.Profile.Contact.Contact(_DbContext);
                }
                return _IContact;
            }
        }

        public Mugurtham.Repository.Profile.Family.IFamily RepositoryFamily
        {
            get
            {
                if (_IFamily == null)
                {
                    _IFamily = new Mugurtham.Repository.Profile.Family.Family(_DbContext);
                }
                return _IFamily;
            }
        }

        public Mugurtham.Repository.Profile.Location.ILocation RepositoryLocation
        {
            get
            {
                if (_ILocation == null)
                {
                    _ILocation = new Mugurtham.Repository.Profile.Location.Location(_DbContext);
                }
                return _ILocation;
            }
        }

        public Mugurtham.Repository.Profile.Reference.IReference RepositoryReference
        {
            get
            {
                if (_IReference == null)
                {
                    _IReference = new Mugurtham.Repository.Profile.Reference.Reference(_DbContext);
                }
                return _IReference;
            }
        }
        public Mugurtham.Repository.Sangam.ISangam RepositorySangam
        {
            get
            {
                if (_ISangam == null)
                {
                    _ISangam = new Mugurtham.Repository.Sangam.Sangam(_DbContext);
                }
                return _ISangam;
            }
        }
        public Mugurtham.Repository.Role.IRole RepositoryRole
        {
            get
            {
                if (_IRole == null)
                {
                    _IRole = new Mugurtham.Repository.Role.Role(_DbContext);
                }
                return _IRole;
            }
        }
        public Mugurtham.Repository.User.IUser RepositoryUser
        {
            get
            {
                if (_IUser == null)
                {
                    _IUser = new Mugurtham.Repository.User.User(_DbContext);
                }
                return _IUser;
            }
        }
        public Mugurtham.Repository.Profile.Raasi.IRaasi RepositoryRaasi
        {
            get
            {
                if (_IRaasi == null)
                {
                    _IRaasi = new Mugurtham.Repository.Profile.Raasi.Raasi(_DbContext);
                }
                return _IRaasi;
            }
        }
        public Mugurtham.Repository.Profile.Amsam.IAmsam RepositoryAmsam
        {
            get
            {
                if (_IAmsam == null)
                {
                    _IAmsam = new Mugurtham.Repository.Profile.Amsam.Amsam(_DbContext);
                }
                return _IAmsam;
            }
        }
        public Mugurtham.Repository.Dashboard.Sangam.IDashboard RepositorySangamDashboardChart
        {
            get
            {
                if (_ISangamDahboardChart == null)
                {
                    _ISangamDahboardChart = new Mugurtham.Repository.Dashboard.Sangam.Dashboard(_DbContext);
                }
                return _ISangamDahboardChart;
            }
        }
        public Mugurtham.Repository.ProfileViewed.IProfileViewed RepositoryProfileViewed
        {
            get
            {
                if (_IProfileViewed == null)
                {
                    _IProfileViewed = new Mugurtham.Repository.ProfileViewed.ProfileViewed(_DbContext);
                }
                return _IProfileViewed;
            }
        }
        public Mugurtham.Repository.ProfileInterested.IProfileInterested RepositoryProfileInterested
        {
            get
            {
                if (_IProfileInterested == null)
                {
                    _IProfileInterested = new Mugurtham.Repository.ProfileInterested.ProfileInterested(_DbContext);
                }
                return _IProfileInterested;
            }
        }
        public Mugurtham.Repository.Profile.Photo.IPhoto RepositoryPhoto
        {
            get
            {
                if (_IPhoto == null)
                {
                    _IPhoto = new Mugurtham.Repository.Profile.Photo.Photo(_DbContext);
                }
                return _IPhoto;
            }
        }


        // ...
        #region IDisposable Members

        ~UnitOfWork()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            if (!this.boolDisposeClosed)
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
                this.boolDisposeClosed = true;
            }
            
            // If this function is being called the user wants to release the
            // resources. lets call the Dispose which will do this for us.
            Dispose(true);

            // Now since we have done the cleanup already there is nothing left
            // for the Finalizer to do. So lets tell the GC not to call it later.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                //someone want the deterministic release of all resources
                //Let us release all the managed resources

                // clean up managed resources
            }
            else
            {
                // Do nothing, no one asked a dispose, the object went out of
                // scope and finalized is called so lets next round of GC 
                // release these resources

                // clean up unmanaged resources
            }
            //never dispose data not getting saved - else analyze and fix to dispose objects
           // _DbContext.Dispose();
            // Release the unmanaged resource in any case as they will not be 
            // released by GC

        }

        #endregion

        
    }
}

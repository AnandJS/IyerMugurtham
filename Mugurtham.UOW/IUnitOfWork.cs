using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.UOW
{
    public interface IUnitOfWork
    {
        //Save pending changes to the data store
        void commit();

        //Profile Repositories
        Mugurtham.Repository.Profile.BasicInfo.IBasicInfo RepositoryBasicInfo { get; }
        Mugurtham.Repository.Profile.Career.ICareer RepositoryCareer { get; }
        Mugurtham.Repository.Profile.Contact.IContact RepositoryContact { get; }
        Mugurtham.Repository.Profile.Family.IFamily RepositoryFamily { get; }
        Mugurtham.Repository.Profile.Location.ILocation RepositoryLocation { get; }
        Mugurtham.Repository.Profile.Reference.IReference RepositoryReference { get; }
        //Sangam Repository
        Mugurtham.Repository.Sangam.ISangam RepositorySangam { get; }
        //Role Repository
        Mugurtham.Repository.Role.IRole RepositoryRole { get; }
        //User Repository
        Mugurtham.Repository.User.IUser RepositoryUser { get; }
        //Raasi Repository
        Mugurtham.Repository.Profile.Raasi.IRaasi RepositoryRaasi { get; }
        //Amsam Repository
        Mugurtham.Repository.Profile.Amsam.IAmsam RepositoryAmsam { get; }
        // Sangam Dashboard Chart
        Mugurtham.Repository.Dashboard.Sangam.IDashboard RepositorySangamDashboardChart { get; }
        // To get View Profiles Notifications
        Mugurtham.Repository.ProfileViewed.IProfileViewed RepositoryProfileViewed { get; }
        // To get Interested Prfiles Notifications
        Mugurtham.Repository.ProfileInterested.IProfileInterested RepositoryProfileInterested { get; }
        // To get Photos
        Mugurtham.Repository.Profile.Photo.IPhoto RepositoryPhoto { get; }
    }
}

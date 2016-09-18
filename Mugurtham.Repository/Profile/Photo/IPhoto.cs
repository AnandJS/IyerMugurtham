using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Repository.Profile.Photo
{
    public interface IPhoto : IRepository<Mugurtham.DTO.Profile.Photo>
    {
        IQueryable<Mugurtham.DTO.Profile.Photo> getProfilePhotos(string ProfileID);
    }
}

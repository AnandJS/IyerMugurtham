using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Mugurtham.Repository.Profile.Photo
{
    /// <summary>
    /// This class is used for implementaion of the IPhoto interface only
    /// </summary> 
    public class Photo : GenericRepository<Mugurtham.DTO.Profile.Photo>, IPhoto
    {
        public Photo(DbContext objDbContext)
            : base(objDbContext)
        {
        }
        public IQueryable<Mugurtham.DTO.Profile.Photo> getProfilePhotos(string ID)
        {
            return GetAll().Where(p => p.ProfileID == ID);
        }
    }
}

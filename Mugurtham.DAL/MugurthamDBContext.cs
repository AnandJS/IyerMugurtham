using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.DTO.Profile;
using Mugurtham.DTO.Sangam;
using Mugurtham.DTO.Role;
using Mugurtham.DTO.User;
using Mugurtham.DTO.ProfileViewed;
using Mugurtham.DTO.ProfileInterested;

namespace Mugurtham.DAL
{
    public class MugurthamDBContext : DbContext
    {
        /*
         Development Server: data source=(local);initial catalog=Mugurtham;user id=sa;password=Welcome@07
         Demo Server: data source=103.235.104.24;initial catalog=DemoMugurtham;user id=DemoMugurthamAdmin;password=Swingsys@1
         Test Server: data source=(local);initial catalog=TestMugurtham;user id=TestMugurthamAdmin;password=Swingsys@1
         Production Server: data source=103.235.104.24;initial catalog=ViswakarmaMugurtham;user id=ViswakarmaMugurthamAdmin;password=Swingsys@1
         Production Server: data source=(local);initial catalog=VishwakarmaMugurtham;user id=VishwakarmaMugurthamAdmin;password=Swingsys@!1
         */

        public MugurthamDBContext()
            : base("name=MugurthamConnectionString")
        {
            Database.SetInitializer<MugurthamDBContext>(null);
        }

        public DbSet<BasicInfo> ProfileBasicInfo { get; set; }
        public DbSet<Career> ProfileCareer { get; set; }
        public DbSet<Contact> ProfileContact { get; set; }
        public DbSet<Family> ProfileFamily { get; set; }
        public DbSet<Location> ProfileLocation { get; set; }
        public DbSet<Reference> ProfileReference { get; set; }
        public DbSet<Sangam> SangamMaster { get; set; }
        public DbSet<Role> RoleMaster { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Raasi> Raasi { get; set; }
        public DbSet<Amsam> Amsam { get; set; }
        public DbSet<ProfileViewed> ProfileViewed { get; set; }
        public DbSet<ProfileInterested> ProfileInterested { get; set; }
        public DbSet<Photo> Photo { get; set; }
        

    }
}

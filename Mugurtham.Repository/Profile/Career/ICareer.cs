using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugurtham.DTO.Profile;


namespace Mugurtham.Repository.Profile.Career
{
    public interface ICareer : IRepository<Mugurtham.DTO.Profile.Career>
    {
        IQueryable<Mugurtham.DTO.Profile.Career> GetIncome(string ProfileID);
    }
}

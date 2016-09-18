using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugurtham.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(string id);
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        void Delete(string id);
    }
}

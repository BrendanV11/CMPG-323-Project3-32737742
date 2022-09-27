using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class Startup
    {
        public interface IGenericRepository<T> where T : class
        {
            T GetById(int id);
            IEnumerable<T> GetAll();
            IEnumerable<T> Find(Expression<Func<T, bool>> expression);
            void Add(T entity);
            void AddRange(IEnumerable<T> entities);
            void Remove(T entity);
            void RemoveRange(IEnumerable<T> entities);
        }

    }
}

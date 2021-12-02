using RotaGeekOffline.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Data
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> CreateOrUpdate(T entity); 
        Task Delete(string id);
        Task<List<T>> GetAll();
        Task<T> FindById(string id);

    }
}

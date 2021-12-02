using RotaGeekOffline.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Data
{
    public abstract class BaseMemoryRepository<T> : IRepository<T> where T : EntityBase
    {
        protected List<T> Items = new List<T>(); 
        public async Task<T> Create(T entity)
        {
            Items.Add(entity);
            return entity;
        }

        public async Task<T> CreateOrUpdate(T entity)
        {
            var storedItem = Items.FirstOrDefault(i => i.Id == entity.Id);
           if (storedItem == null)
            {
                Items.Add(entity);
            }
            else
            {
                storedItem = entity;
            }
            return entity;
        }

        public async Task Delete(string id)
        {
            Items.RemoveAll(i => i.Id == id);
        }

        public async Task<T> FindById(string id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);
            return item;
        }

        public async Task<List<T>> GetAll()
        {
            return Items;
        }

      
    }
}

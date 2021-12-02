using RotaGeekOffline.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Data
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
        Task<ProductEntity> FindBySku(string sku, string storeId);
        Task<List<ProductEntity>> FindByStoreId(string storeId);
    }
}

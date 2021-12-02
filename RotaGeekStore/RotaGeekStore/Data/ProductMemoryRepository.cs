using RotaGeekOffline.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Data
{
    public class ProductMemoryRepository : BaseMemoryRepository<ProductEntity>, IProductRepository
    {
        public async Task<ProductEntity?> FindBySku(string sku, string storeId)
        {
            var product = Items.FirstOrDefault(p=> p.SKU == sku && p.StoreId == storeId);
            return product;
        }

        public async Task<List<ProductEntity>> FindByStoreId(string storeId)
        {
            var products = Items.Where(p=>p.StoreId == storeId).ToList();
            return products;
        }
    }
}

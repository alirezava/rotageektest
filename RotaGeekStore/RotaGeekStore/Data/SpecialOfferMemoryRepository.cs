using RotaGeekOffline.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Data
{
    public class SpecialOfferMemoryRepository : BaseMemoryRepository<SpecialOfferEntity>, ISpecialOfferRepository
    {
        public async Task<SpecialOfferEntity?> FindBySku(string sku, string storeId)
        {
            var offer = Items.FirstOrDefault(o=>o.SKU == sku && o.StoreId == storeId);
            return offer;
        }
    }
}

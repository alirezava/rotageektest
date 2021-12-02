using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Domain.Entity
{
   public class ProductEntity : EntityBase
    { 
        public string SKU { get; private set; }
        public decimal Price { get; private set; }
        public string Name { get; private set; }
        public string StoreId { get; private set; }

        public ProductEntity(string sku, decimal price, string name, string storeId)
        {
            SKU = sku;
            Price = price;
            Name = name;
            StoreId = storeId; 
        }

        public override string ToString()
        {
            return $"{Name}: £{Price} : {SKU}";
        }
    }
}

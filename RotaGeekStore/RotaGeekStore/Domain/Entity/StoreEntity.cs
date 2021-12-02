using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Domain.Entity
{
    public class StoreEntity : EntityBase
    {
        public string StoreName { get; private set; }
        public Region Region { get; private set; }

        public StoreEntity(string storeName, Region region)
        {
            StoreName = storeName;      
            Region = region;
        }

        public override string ToString()
        {
            return StoreName + " - Region : " + Region.ToString();
        }
    }
}

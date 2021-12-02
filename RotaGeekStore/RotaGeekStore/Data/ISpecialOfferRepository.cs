using RotaGeekOffline.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Data
{
    public interface ISpecialOfferRepository : IRepository<SpecialOfferEntity>
    {
        Task<SpecialOfferEntity> FindBySku(string sku, string storeId);
    }
}

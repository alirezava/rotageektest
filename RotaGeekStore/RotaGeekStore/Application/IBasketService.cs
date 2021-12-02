using RotaGeekOffline.Domain;
using RotaGeekOffline.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Application
{
    public interface IBasketService
    { 
        Task<BasketSummaryEntity> ScanItem(string sku, string basketId, string storeId);

        Task<BasketSummaryEntity> GetBasketTotal(string basketId);
    }
}

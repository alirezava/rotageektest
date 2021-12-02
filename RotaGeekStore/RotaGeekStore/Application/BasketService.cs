using RotaGeekOffline.Data;
using RotaGeekOffline.Domain;
using RotaGeekOffline.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Application
{
    public class BasketService : IBasketService
    {
        private IBasketRepository _basketRepository { get; }
        private IProductRepository _productRepository { get; } 
        private IPriceEvaluator _priceEvaluator { get; }
        public BasketService(IBasketRepository basketRepository, IProductRepository productRepository, IStoreRepository storeRepository, IPriceEvaluator priceEvaluator)
        {
            _basketRepository = basketRepository;
            _productRepository = productRepository; 
            _priceEvaluator = priceEvaluator;
        }  


 
 
        public async Task<BasketSummaryEntity> ScanItem(string sku, string basketId, string storeId)
        {
            var basket = await _basketRepository.FindById(basketId);

            if(basket == null)
            {
                basket = new BasketEntity(basketId, storeId);
            }

            var product = await _productRepository.FindBySku(sku, storeId);

            if(product != null)
            {
                basket.AddProduct(product);
            }

            await _basketRepository.CreateOrUpdate(basket);
            var summary = await GetBasketTotal(basketId);
            return summary;

        }

        public async Task<BasketSummaryEntity> GetBasketTotal(string basketId)
        {
            var summary = await _priceEvaluator.EvaluateBasket(basketId);
            return summary;
        }

 
    }
}

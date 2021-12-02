using RotaGeekOffline.Data;
using RotaGeekOffline.Domain;
using RotaGeekOffline.Domain.Entity;
using RotaGeekOffline.Domain.Service;
using RotaGeekOffline.Domain.Service.Regulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Application
{
    public class PriceEvaluator : IPriceEvaluator
    {
        private IProductRepository _productRepository { get; }
        private ISpecialOfferRepository _specialOfferRepository { get; }
        private IBasketRepository _basketRepository { get; }
        private IStoreRepository _storeRepository { get; }

        public PriceEvaluator(IProductRepository productRepository, ISpecialOfferRepository specialOfferRepository, IBasketRepository basketRepository, IStoreRepository storeRepository)
        {
            _productRepository = productRepository;
            _specialOfferRepository = specialOfferRepository;
            _basketRepository = basketRepository;
            _storeRepository = storeRepository;
        }

 
        public async Task<BasketSummaryEntity> EvaluateBasket(string basketId)
        {
            var basket = await _basketRepository.FindById(basketId);
            var store = await _storeRepository.FindById(basket.StoreId);
            var groupedProducts = basket.Products.GroupBy(p => p.SKU);

            decimal basketTotal = 0;

            foreach (var item in groupedProducts)
            {
                var specialOffer = await _specialOfferRepository.FindBySku(item.Key, basket.StoreId);
                basketTotal += BasketCalculatorService.CalculateProductTotal(item.Count(), item.First(), specialOffer);
            }
            
            RegulationContext regulationContext = new RegulationContext(basket, store.Region);
            decimal implicitCost=  regulationContext.CalculateImplicitCost();

            return new BasketSummaryEntity(basketTotal, implicitCost);


        }
    }
}

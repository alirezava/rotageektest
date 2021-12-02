using RotaGeekOffline.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Domain.Service
{
    public static class BasketCalculatorService
    {

        public static decimal CalculateProductTotal(int count, ProductEntity product, SpecialOfferEntity? offer)
        {
            return offer == null ? CalculateProductTotal(count, product) : CalculateProductTotalWithOffer(count, product, offer);
        }
        private static decimal CalculateProductTotalWithOffer(int count, ProductEntity product,  SpecialOfferEntity offer)
        {            
            int specialOfferCount = offer.CalulateOfferApplicableCount(count);
            int noneDiscounted = specialOfferCount == 0 ? count : count - offer.CalculateItemCountDiscounted(count);
            decimal total = (noneDiscounted * product.Price) + (specialOfferCount * offer.DiscountedPrice);
            return total;
        }
        private static decimal CalculateProductTotal(int count, ProductEntity product)
        {
            decimal total = (count * product.Price);
            return total;
        }
         
    }
}

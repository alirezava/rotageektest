using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Domain.Entity
{
    public class SpecialOfferEntity : EntityBase
    {
        public string SKU { get; private set; }
        public int QualificationQuantity {  get; private set; }
        public decimal DiscountedPrice { get; private set; }

        public string StoreId { get; private set; }
        public SpecialOfferEntity(string sku,int qualificationQuanity, decimal discountedPrice, string storeId)
        {
            SKU = sku;
            DiscountedPrice = discountedPrice;
            QualificationQuantity = qualificationQuanity;
            StoreId = storeId;
        }

        public int CalulateOfferApplicableCount(int count)
        {
            if (count < QualificationQuantity)
            {
                return 0;
            }
            return count/QualificationQuantity;
        }
        
        public int CalculateItemCountDiscounted(int count)
        {
            int offerCount = CalulateOfferApplicableCount(count);
            int offeredQuantity = QualificationQuantity * offerCount;
            return offeredQuantity;
        }
    }
}

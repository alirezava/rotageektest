using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Domain.Entity
{
    public  class BasketSummaryEntity : EntityBase
    {
        public decimal ItemTotal { get; private set; } = 0;
        public decimal ImplicitTotal { get; private set; } = 0;
        public decimal Total => ItemTotal + ImplicitTotal;

        public BasketSummaryEntity(decimal itemTotal, decimal implicitTotal)
        {
            ItemTotal = itemTotal;
            ImplicitTotal = implicitTotal;
        }

        public override string ToString()
        {
            return $"Item Total : {ItemTotal} - Bag Cost : {ImplicitTotal} - Total Cost : {Total}";
        }
    }
}

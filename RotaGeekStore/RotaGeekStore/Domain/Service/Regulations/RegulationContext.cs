using RotaGeekOffline.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Domain.Service.Regulations
{
    public class RegulationContext
    {
        private IRegionalRegulation? _regionalRegulation;
        private BasketEntity _basketEntity { get; }
         

        public RegulationContext(BasketEntity basketEntity, Region region)
        {
            _basketEntity = basketEntity;
            switch (region)
            {
                case Region.UK:
                    _regionalRegulation = new UkRegulation();
                    break;
                case Region.Wales:
                    _regionalRegulation = new WalesRegulation();
                    break;
                default:
                    break;
            }
        }

        public decimal CalculateImplicitCost()
        {
            if(_regionalRegulation == null)
            {
                return 0;
            }
            var calculatedTotal = _regionalRegulation.Calculate(_basketEntity);
            return calculatedTotal; 
        }

    }
}

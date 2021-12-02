using RotaGeekOffline.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Domain.Service.Regulations
{
    public class UkRegulation : IRegionalRegulation
    {
        public decimal Calculate(BasketEntity basket)
        {
            return basket.Products.Count * 0.05m;
        }
    }
}

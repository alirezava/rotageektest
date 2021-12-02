using RotaGeekOffline.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Domain.Service.Regulations
{
    public interface IRegionalRegulation
    {
        decimal Calculate(BasketEntity basket);
    }
}

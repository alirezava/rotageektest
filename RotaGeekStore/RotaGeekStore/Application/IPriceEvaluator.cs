using RotaGeekOffline.Domain;
using RotaGeekOffline.Domain.Entity;
using RotaGeekOffline.Domain.Service.Regulations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline.Application
{
    public interface IPriceEvaluator
    {
        Task<BasketSummaryEntity> EvaluateBasket(string basketId);
    }
}

using RotaGeekOffline.Domain;
using RotaGeekOffline.Domain.Entity; 

namespace RotaGeekOffline.Application
{
    public interface IStoreService
    {
        Task<string> StoreSelection(); 
        Task ProductSelection(string storeId); 
    }
}

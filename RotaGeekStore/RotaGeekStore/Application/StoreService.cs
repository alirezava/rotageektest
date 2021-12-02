using RotaGeekOffline.Data;
using RotaGeekOffline.Domain;
using RotaGeekOffline.Domain.Entity;
using RotaGeekOffline.Domain.Service.Regulations;

namespace RotaGeekOffline.Application
{
    public class StoreService : IStoreService
    {

        public StoreService(IProductRepository productRepository, IStoreRepository storeRepository, IBasketService basketService)
        {
            ProductRepository = productRepository;
            StoreRepository = storeRepository;
            BasketService = basketService;
        }

        public IProductRepository ProductRepository { get; }
        public IStoreRepository StoreRepository { get; }
        public IBasketService BasketService { get; }

       
        public async Task ProductSelection(string storeId)
        { 
            BasketEntity basketEntity = new BasketEntity(storeId);

            var products = await ProductRepository.FindByStoreId(storeId);

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"[{i}]: {products[i]}");
            }
             
            while (true)
            {
                Console.WriteLine("Please select your product");
                Console.WriteLine("Type C to checkout");
                var input = Console.ReadLine(); 
                if(input?.Trim() == "C")
                {
                    Console.WriteLine("Checking out");
                    break;
                }
                int selectedProductIndex;
                var intSelected = int.TryParse(input, out selectedProductIndex);
                if (!intSelected)
                {
                    Console.WriteLine("Please select an integer");
                    continue;
                }
                if (selectedProductIndex >= products.Count)
                {
                    Console.WriteLine("Please select an integer within range");
                    continue;
                }
                var product = products[selectedProductIndex];
                var summary = await BasketService.ScanItem(product.SKU, basketEntity.Id, storeId);
                Console.WriteLine(summary);                  
            }
        }

        public async Task<string> StoreSelection()
        {
            Console.WriteLine("Please select your store");
            var stores = await StoreRepository.GetAll();

            for (int i = 0; i < stores.Count; i++)
            {
                Console.WriteLine($"[{i}]: {stores[i]}");
            }

            int selectedStore;
            while (true)
            {
                var intSelected = int.TryParse(Console.ReadLine(), out selectedStore);
                if (!intSelected)
                {
                    Console.WriteLine("Please select an integer");
                    continue;
                }
                if (selectedStore >= stores.Count)
                {
                    Console.WriteLine("Please select an integer within range");
                    continue;
                }
                break;
            }
            return stores[selectedStore].Id;
        }
    }
}

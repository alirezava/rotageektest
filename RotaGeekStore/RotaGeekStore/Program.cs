using RotaGeekOffline;
using RotaGeekOffline.Application;
using RotaGeekOffline.Data;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Loading seed data");
        var basketRepository =new BasketMemoryRepository();
        var storeRepository = new StoreMemoryRepository();
        var specialOfferRepository = new SpecialOfferMemoryRepository();
        var productRepository = new ProductMemoryRepository();

        var priceEvaluator = new PriceEvaluator(productRepository, specialOfferRepository, basketRepository, storeRepository);
        var basketService = new BasketService(basketRepository, productRepository, storeRepository, priceEvaluator);
        var storeService = new StoreService(productRepository, storeRepository, basketService);

        await SeedData.PopulateStore(storeRepository, productRepository,specialOfferRepository);

        var storeId = await storeService.StoreSelection();

        await storeService.ProductSelection(storeId);
        
    }
}
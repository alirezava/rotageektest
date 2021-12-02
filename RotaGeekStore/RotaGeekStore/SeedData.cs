using RotaGeekOffline.Data;
using RotaGeekOffline.Domain;
using RotaGeekOffline.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaGeekOffline
{
    public class SeedData
    {
        public static async Task PopulateStore(IStoreRepository storeRepository, IProductRepository productRepository, ISpecialOfferRepository specialOfferRepository) {
            var ukAsdaStore = await storeRepository.CreateOrUpdate(new StoreEntity("Asda UK", Region.UK));
            var walesAsdaStore = await storeRepository.CreateOrUpdate(new StoreEntity("Asda Wales", Region.Wales));

            var apple = new ProductEntity("A", 50.0m, "Apple", ukAsdaStore.Id);
            var orange = new ProductEntity("B", 30.0m, "Orange", ukAsdaStore.Id);
            var tomate = new ProductEntity("C", 20.0m, "tomato", ukAsdaStore.Id);
            var strawberry = new ProductEntity("D",15.0m, "Strawberry", ukAsdaStore.Id);

            var applew = new ProductEntity("A",50.0m, "Apple", walesAsdaStore.Id);
            var orangew = new ProductEntity("B",30.0m, "Orange", walesAsdaStore.Id);
            var tomatew= new ProductEntity("C", 20.0m, "tomato", walesAsdaStore.Id);
            var strawberryw = new ProductEntity("D",15.0m, "Strawberry", walesAsdaStore.Id);

            await productRepository.CreateOrUpdate(apple);
            await productRepository.CreateOrUpdate(orange);
            await productRepository.CreateOrUpdate(tomate);
            await productRepository.CreateOrUpdate(strawberry);

            await productRepository.CreateOrUpdate(applew);
            await productRepository.CreateOrUpdate(orangew);
            await productRepository.CreateOrUpdate(tomatew);
            await productRepository.CreateOrUpdate(strawberryw);

            var specialOfferA = new SpecialOfferEntity(apple.SKU, 3, 130, ukAsdaStore.Id);
            var specialOfferB = new SpecialOfferEntity(orange.SKU, 2, 45, ukAsdaStore.Id);

            var specialOfferAw = new SpecialOfferEntity(apple.SKU, 3, 130, walesAsdaStore.Id);
            var specialOfferBw = new SpecialOfferEntity(orange.SKU, 2, 45, walesAsdaStore.Id);

            await specialOfferRepository.CreateOrUpdate(specialOfferA);
            await specialOfferRepository.CreateOrUpdate(specialOfferB);
            await specialOfferRepository.CreateOrUpdate(specialOfferAw);
            await specialOfferRepository.CreateOrUpdate(specialOfferBw);
        }
    }
}


namespace RotaGeekOffline.Domain.Entity
{
    public class BasketEntity : EntityBase
    { 
        public string StoreId { get; private set; }
        public List<ProductEntity> Products { get; private set; } = new List<ProductEntity>();

        public BasketEntity(string id, string storeId)
        {
            Id = id;
            StoreId = storeId;
        }
        public BasketEntity(string storeId)
        {
            StoreId = storeId;
        }

        public void AddProduct(ProductEntity productEntity)
        {
            Products.Add(productEntity);
        }
 
    }
}

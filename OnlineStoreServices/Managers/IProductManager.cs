using DataAccess.Context.Entity;

namespace OnlineStoreServices.Managers
{
    public interface IProductManager
    {
        public IEnumerable<Product> GetProducts();
        public IEnumerable<Product> GetProductsbyCategory(int? categoryId);
        public Product GetProductsByID(int id);
        public void AddProducttoDB(Product newProduct);
    }
}

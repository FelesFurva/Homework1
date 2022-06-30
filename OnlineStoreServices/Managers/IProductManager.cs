using DataAccess.Context.Entity;

namespace OnlineStoreServices.Managers
{
    public interface IProductManager
    {
        public IEnumerable<Product> GetProducts();
        public IEnumerable<Product> GetProductsbySubCategory(int categoryId);
        public Product GetProductsByID(int id);
        public void AddProducttoDB(Product newProduct);
    }
}

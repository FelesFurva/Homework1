using DataAccess.Context;
using DataAccess.Context.Entity;
using Microsoft.EntityFrameworkCore;

namespace OnlineStoreServices.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly WebShopDBContext webShopDB;

        public ProductManager(WebShopDBContext webShopDB)
        {
            this.webShopDB = webShopDB;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = webShopDB.Products;
            return products;
        }

        public IEnumerable<Product> GetProductsbyCategory(int? categoryId)
        {
            var ProductsByCategoryId = webShopDB.Categories
                                          .Include(c => c.Products)
                                          .Where(c => c.CategoryId == categoryId).SelectMany(c => c.Products);
            return ProductsByCategoryId;
        }

        public Product GetProductsByID(int id)
        {
            var ProductById = webShopDB.Products.FirstOrDefault(p => p.ProductId == id);

            return ProductById;
        }

        public void AddProducttoDB(Product newProduct)
        {
            webShopDB.Products.Add(newProduct);
            webShopDB.SaveChanges();
        }

    }
}

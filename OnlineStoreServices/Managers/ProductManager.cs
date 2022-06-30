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

        public IEnumerable<Product> GetProductsbySubCategory(int subCategoryId)
        {
            var ProductsBySubCategoryId = webShopDB.SubCategories
                                          .Include(sc => sc.Products)
                                          .Where(sc => sc.SubCategoryId == subCategoryId).SelectMany(sc => sc.Products);
            return ProductsBySubCategoryId.ToList();
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

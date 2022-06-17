using Homework1.Context;
using Homework1.Context.Entity;
using Homework1.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework1
{
    public class DatabaseManager
    {
        private readonly WebShopDBContext webShopDB;

        public DatabaseManager(WebShopDBContext webShopDB)
        {
            this.webShopDB = webShopDB;
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            var categories = webShopDB.Categories.Select(categories => new CategoryModel
            {
                CategoryId = categories.CategoryId,
                CategoryName = categories.CategoryName
            });
            return categories;
        }

        public void AddCategoryDB(string CategoryName)
        {
            var newCategory = new Category
            {
                CategoryName = CategoryName,
            };

            webShopDB.Categories.Add(newCategory);
            webShopDB.SaveChanges();
        }

        public IEnumerable<ProductsModel> GetProducts()
        {
            var products = webShopDB.Products.Select(products => new ProductsModel
            {
                ProductId = products.ProductId,
                Name = products.Name,
                Description = products.Description,
                Price = products.Price,
            });
            return products;
        }

        public ProductsModel GetProductsByID(int id)
        {
            var Product = webShopDB.Products.FirstOrDefault(p => p.ProductId == id);

            var ProductById = new ProductsModel
            {
                ProductId = Product.ProductId,
                Name = Product.Name,
                Description = Product.Description,
                Price = Product.Price,
                CategoryID = Product.CategoryID,
                Location = Product.Location
            };
            return ProductById;
        }

        public void AddProducttoDB(ProductCreateModel product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryID = product.CategoryID,
                Location = product.Location
            };
            webShopDB.Products.Add(newProduct);
            webShopDB.SaveChanges();
        }

        public CategoryModel GetItemsByCategorybyId(int id)
        {
            var SelectedCategory = webShopDB.Categories
                                            .Include(c => c.Products)
                                            .SingleOrDefault(c => c.CategoryId == id);
            var CategoryWithProducts = new CategoryModel
            {
                CategoryId = SelectedCategory.CategoryId,
                CategoryName = SelectedCategory.CategoryName,
                Products = SelectedCategory.Products.Select(Products => new ProductsModel
                {
                    ProductId = Products.ProductId,
                    Name = Products.Name,
                    Description = Products.Description,
                    Price = Products.Price,
                    CategoryID = Products.CategoryID,
                    Location = Products.Location,
                })
            };
            return CategoryWithProducts;
        }
    }
}

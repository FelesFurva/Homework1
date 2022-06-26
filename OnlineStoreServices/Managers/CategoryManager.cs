using DataAccess.Context;
using DataAccess.Context.Entity;
using Microsoft.EntityFrameworkCore;

namespace OnlineStoreServices.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly WebShopDBContext webShopDB;

        public CategoryManager(WebShopDBContext webShopDB)
        {
            this.webShopDB = webShopDB;
        }

        public IEnumerable<Category> GetCategories()
        {
            var categories = webShopDB.Categories;
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

        public Category GetItemsByCategorybyId(int id)
        {
            var SelectedCategory = webShopDB.Categories
                                            .Include(c => c.Products)
                                            .SingleOrDefault(c => c.CategoryId == id);
            return SelectedCategory;
        }
    }
}

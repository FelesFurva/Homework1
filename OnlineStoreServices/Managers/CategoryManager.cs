using DataAccess.Context;
using DataAccess.Context.Entity;
using Microsoft.EntityFrameworkCore;

namespace OnlineStoreServices.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly WebShopDBContext _webShopDB;

        public CategoryManager(WebShopDBContext webShopDB)
        {
            _webShopDB = webShopDB;
        }

        public IEnumerable<Category> GetCategories()
        {
            var categories = _webShopDB.Categories;
            return categories;
        }

        public IEnumerable<Category> GetCategoriesWithSubs()
        {
            var categories = _webShopDB.Categories.Include(c => c.SubCategory);
            return categories;            
        }

        public void AddCategoryDB(string CategoryName)
        {
            var newCategory = new Category
            {
                CategoryName = CategoryName,
            };

            _webShopDB.Categories.Add(newCategory);
            _webShopDB.SaveChanges();
        }

        public Category GetSubCategoryByCategoryId(int id)
        {
            var SelectedCategory = _webShopDB.Categories
                                            .Include(c => c.SubCategory)
                                            .SingleOrDefault(c => c.CategoryId == id);
            return SelectedCategory;
        }
    }
}

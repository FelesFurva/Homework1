using DataAccess.Context;
using DataAccess.Context.Entity;
using Microsoft.EntityFrameworkCore;

namespace OnlineStoreServices.Managers
{
    public class SubCategoryManager : ISubCategoryManager
    {
        private readonly WebShopDBContext webShopDB;

        public SubCategoryManager(WebShopDBContext webShopDB)
        {
            this.webShopDB = webShopDB;
        }

        public IEnumerable<SubCategory> GetSubCategories()
        {
            var subCategory = webShopDB.SubCategories;
            return subCategory;
        }

        public void AddSubCategoryDB(SubCategory subCategory)
        {
            var newSubCategory = new SubCategory
            {
                SubCategoryName = subCategory.SubCategoryName,
                CategoryId = subCategory.CategoryId,
            };

            webShopDB.SubCategories.Add(newSubCategory);
            webShopDB.SaveChanges();
        }

        public SubCategory GetItemsBySubCategoryId(int id)
        {
            var SelectedSubCategory = webShopDB.SubCategories
                                            .Include(sc => sc.Products)
                                            .SingleOrDefault(sc => sc.SubCategoryId == id);
            return SelectedSubCategory;
        }

        public IEnumerable<SubCategory> GetSubCategoriesbyCategory(int categoryId)
        {
            var SubCategorybyCategory = webShopDB.Categories
                                          .Include(c => c.SubCategory)
                                          .Where(c => c.CategoryId == categoryId).SelectMany(c => c.SubCategory);
            return SubCategorybyCategory.ToList();
        }
    }
}

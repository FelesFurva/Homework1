using DataAccess.Context.Entity;

namespace OnlineStoreServices.Managers
{
    public interface ICategoryManager 
    {
        public IEnumerable<Category> GetCategories();
        public void AddCategoryDB(string CategoryName);
        public Category GetSubCategoryByCategoryId(int id);
        public IEnumerable<Category> GetCategoriesWithSubs();
    }
}

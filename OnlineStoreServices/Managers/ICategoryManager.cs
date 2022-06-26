using DataAccess.Context.Entity;

namespace OnlineStoreServices.Managers
{
    public interface ICategoryManager 
    {
        public IEnumerable<Category> GetCategories();
        public void AddCategoryDB(string CategoryName);
        public Category GetItemsByCategorybyId(int id);
    }
}

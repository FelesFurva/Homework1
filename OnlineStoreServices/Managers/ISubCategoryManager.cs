using DataAccess.Context.Entity;

namespace OnlineStoreServices.Managers
{
    public interface ISubCategoryManager
    {
        public SubCategory GetItemsBySubCategoryId(int id);
        public void AddSubCategoryDB(SubCategory subCategory);
        public IEnumerable<SubCategory> GetSubCategories();
        public IEnumerable<SubCategory> GetSubCategoriesbyCategory(int categoryId);

    }
}

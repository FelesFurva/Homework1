using DataAccess.Context.Entity;
using OnlineStore.Models;

namespace OnlineStore.Extention
{
    public static class CategoryExtension
    {
        public static CategoryModel ToModel(this Category category)
        {
            return new CategoryModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                SubCategories = category.SubCategory?.Select(subCategory => subCategory.ToModel())
            };
        }

        public static IEnumerable<CategoryModel> ToModel(this IEnumerable<Category> categories)
        {
            return categories.Select(category => category.ToModel());
        }
    }
}

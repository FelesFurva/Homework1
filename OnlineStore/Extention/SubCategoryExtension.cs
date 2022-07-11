using DataAccess.Context.Entity;
using OnlineStore.Models;

namespace OnlineStore.Extention
{
    public static class SubCategoryExtension
    {
        public static SubCategoryModel ToModel(this SubCategory subCategory)
        {
            return new SubCategoryModel
            {
                SubCategoryId = subCategory.SubCategoryId,
                SubCategoryName = subCategory.SubCategoryName,
                CategoryId = subCategory.CategoryId,
                Products = subCategory.Products?.Select(product => product.ToModel())
            };
        }

        public static IEnumerable<SubCategoryModel> ToModel(this IEnumerable<SubCategory> subCategories)
        {
            return subCategories.Select(sc => sc.ToModel());
        }

        public static SubCategory ToEntity(this SubCategoryModel subCategoryModel)
        {
            return new SubCategory
            {
                CategoryId = subCategoryModel.CategoryId,
                SubCategoryName = subCategoryModel.SubCategoryName,
            };
        }
    }
}

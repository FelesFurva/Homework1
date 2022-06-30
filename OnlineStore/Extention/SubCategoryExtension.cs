using DataAccess.Context.Entity;
using OnlineStore.Models;

namespace OnlineStore.Extention
{
    public static class SubCategoryExtension
    {
        public static SubCategoryModel ToSubCategoryModel(this SubCategory subCategory)
        {
            return new SubCategoryModel
            {
                SubCategoryId = subCategory.SubCategoryId,
                SubCategoryName = subCategory.SubCategoryName,
                CategoryId = subCategory.CategoryId,
                Products = subCategory.Products?.Select(product => product.ToProductModel())
            };
        }
    }
}

using DataAccess.Context.Entity;
using OnlineStore.Models;

namespace OnlineStore.Extention
{
    public static class ProductExtension
    {
        public static ProductsModel ToProductModel(this Product product)
        {
            return new ProductsModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Location = product.Location,
                Description = product.Description,
                SubCategoryID = product.SubCategoryID,
                Price = product.Price,
            };
        }
    }
}

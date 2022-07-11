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
                Filepath = product.Filepath
            };
        }

        public static Product ToEntity(this ProductsModel productsModel)
        {
            return new Product
            {
                ProductId = productsModel.ProductId,
                Name = productsModel.Name,
                Location = productsModel.Location,
                Description = productsModel.Description,
                SubCategoryID = productsModel.SubCategoryID,
                Price = productsModel.Price,
                Filepath = productsModel.Filepath
            };
        }

        public static IEnumerable<Product> ToEntity(this IEnumerable<ProductsModel> productsModels)
        {
            return productsModels.Select(p => p.ToEntity());
        }
    }
}

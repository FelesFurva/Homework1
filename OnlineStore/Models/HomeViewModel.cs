namespace OnlineStore.Models
{
    public class HomeViewModel
    {
        public IEnumerable<CategoryModel> CategoriesList { get; set; }
        public IEnumerable<ProductsModel> Products { get; set; }

    }
}

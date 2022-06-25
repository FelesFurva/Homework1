namespace OnlineStore.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<ProductsModel> Products { get; set; }
    }
}

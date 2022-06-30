namespace OnlineStore.Models
{
    public class SubCategoryModel
    {
        public int SubCategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public int? CategoryId { get; set; }
        public virtual IEnumerable<ProductsModel> Products { get; set; }
    }
}

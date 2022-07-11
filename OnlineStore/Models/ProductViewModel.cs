namespace OnlineStore.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int SubCategoryID { get; set; }
        public string Location { get; set; }
        public IEnumerable<SubCategoryModel> SubCategories { get; set; }
        public string Filepath { get; set; }
    }
}

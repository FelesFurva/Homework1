namespace OnlineStore.Models
{
    public class ProductCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public string Location { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}

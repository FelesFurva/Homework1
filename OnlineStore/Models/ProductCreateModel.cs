namespace OnlineStore.Models
{
    public class ProductCreateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int SubCategoryID { get; set; }
        public string Location { get; set; }
    }
}

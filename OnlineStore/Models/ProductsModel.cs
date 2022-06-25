namespace OnlineStore.Models
{
    public class ProductsModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public string Location { get; set; }

    }
}

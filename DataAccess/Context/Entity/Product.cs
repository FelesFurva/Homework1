namespace DataAccess.Context.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string Filepath { get; set; }
        public int SubCategoryID { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
    }
}

namespace DataAccess.Context.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Location { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}

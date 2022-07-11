namespace OnlineStore.Models
{
    public class CartItemModel
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public int CartId { get; set; }
        public virtual CartViewModel Cart { get; set; }
        public int ProductId { get; set; }
        public virtual ProductsModel Product { get; set; }
        public decimal Price => Product.Price;
        public decimal ProductTotal => Quantity * Price;
    }
}

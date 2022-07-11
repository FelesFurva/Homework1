namespace OnlineStore.Models
{
    public class OrderItemViewModel
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public ProductsModel Product { get; set; }
        public decimal ProductTotal => Quantity * Price;
    }
}

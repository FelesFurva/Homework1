namespace OnlineStore.Models
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public IEnumerable<CartItemModel> Items { get; set; }
        public decimal OrderTotal => Items.Sum(i => i.ProductTotal);
    }
}

using DataAccess.Context.Entity;

namespace OnlineStore.Models
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public IEnumerable<CartItemModel> Items { get; set; }

        public double OrderTotal => Items.Sum(i => i.ProductTotal);
    }
}

using DataAccess.Context.Entity;

namespace OnlineStore.Models
{
    public class CartItemModel
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public double ProductTotal => Quantity * Product.Price;
    }
}

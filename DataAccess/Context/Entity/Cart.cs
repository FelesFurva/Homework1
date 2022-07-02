namespace DataAccess.Context.Entity
{
    public class Cart
    {
        public int CartId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public IEnumerable<CartItem> Items { get; set; }
    }
}

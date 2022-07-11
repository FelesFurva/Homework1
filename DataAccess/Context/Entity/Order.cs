namespace DataAccess.Context.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderItem> OrderedItems { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal OrderTotalSum { get; set; }
    }
}

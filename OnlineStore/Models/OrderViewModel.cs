using DataAccess.Context.Entity;

namespace OnlineStore.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public IEnumerable<OrderItemViewModel> OrderedItems { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal OrderTotalSum { get; set; }
    }
}

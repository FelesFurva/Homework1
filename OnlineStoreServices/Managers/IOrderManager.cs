using DataAccess.Context.Entity;

namespace OnlineStoreServices.Managers
{
    public interface IOrderManager
    {
        IEnumerable<OrderItem> GetOrderItems(int userId);
        IEnumerable<Order> GetAllOrders(int userId);
        void AddOrdertoDb(Order newOrder);
        Order GetOrderbyId(int orderId);
    }
}

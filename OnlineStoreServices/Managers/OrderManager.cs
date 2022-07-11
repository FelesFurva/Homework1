using DataAccess.Context;
using DataAccess.Context.Entity;
using Microsoft.EntityFrameworkCore;

namespace OnlineStoreServices.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly WebShopDBContext _webShopDB;

        public OrderManager(WebShopDBContext webShopDB)
        {
            _webShopDB = webShopDB;
        }

        public IEnumerable<OrderItem> GetOrderItems(int orderId)
        {
            var order = _webShopDB.Order.Include(c => c.OrderedItems).ThenInclude(c => c.Product)
                                        .SingleOrDefault(c => c.OrderId == orderId);
            var orderItems = order.OrderedItems.Where(c => c.OrderId == order.OrderId);
            return orderItems;
        }
        public Order GetOrderbyId(int orderId)
        {
            var order = _webShopDB.Order.Include(c => c.OrderedItems).ThenInclude(c => c.Product)
                                        .SingleOrDefault(c => c.OrderId == orderId);
            return order;
        }

        public IEnumerable<Order> GetAllOrders(int userId)
        {
            var orders = _webShopDB.Order.Include(c => c.OrderedItems).Where(o => o.UserId == userId);
            return orders;
        }

        public void AddOrdertoDb(Order newOrder)
        {
            _webShopDB.Order.Add(newOrder);
            _webShopDB.SaveChanges();
        }

    }
}

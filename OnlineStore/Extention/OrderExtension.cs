using DataAccess.Context.Entity;
using OnlineStore.Models;

namespace OnlineStore.Extention
{
    public static class OrderExtension
    {
        public static OrderViewModel ToViewModel(this Order order)
        {
            var orderModel = new OrderViewModel
            {
                UserId = order.UserId,
                OrderId = order.OrderId,
                OrderedItems = order.OrderedItems.ToViewModel(),
                CreatedDate = order.CreatedDate,
                OrderTotalSum = order.OrderTotalSum,
            };
            return orderModel;
        }

        public static Order ToEntity(this OrderViewModel orderModel)
        {
            return new Order 
            {
                UserId= orderModel.UserId,
                OrderId = orderModel.OrderId,
                OrderTotalSum = orderModel.OrderTotalSum,
                CreatedDate = orderModel.CreatedDate,
                OrderedItems = orderModel.OrderedItems.ToEntity(),
            };
        }

        public static OrderItem ToEntity(this OrderItemViewModel orderItemModel)
        {
            return new OrderItem
            {
                OrderId = orderItemModel.OrderId,
                Price = orderItemModel.Price,
                Quantity = orderItemModel.Quantity,
                ProductId = orderItemModel.ProductId,
            };
        }

        public static OrderItemViewModel ToViewModel(this OrderItem orderItem)
        {
            var orderItemModel = new OrderItemViewModel
            {
                OrderItemId = orderItem.OrderItemId,
                OrderId = orderItem.OrderId,
                Price = orderItem.Price,
                Quantity = orderItem.Quantity,
                ProductId = orderItem.ProductId,
                Product = orderItem.Product.ToProductModel(),
            };
            return orderItemModel;
        }

        public static OrderItemViewModel ToOrderViewModel(this CartItemModel cartItem)
        {
            var newOrderItem = new OrderItemViewModel
            {
                Price = cartItem.Price,
                Quantity = cartItem.Quantity,
                ProductId = cartItem.ProductId,
                Product = cartItem.Product
            };
            return newOrderItem;
        }

        public static IEnumerable<OrderItemViewModel> ToViewModel(this IEnumerable<OrderItem> orderItems)
        {
            return orderItems.Select(o => o.ToViewModel());
        }

        public static IEnumerable<OrderViewModel> ToViewModel(this IEnumerable<Order> orders)
        {
            return orders.Select(o => o.ToViewModel());
        }

        public static IEnumerable<OrderItemViewModel> ToOrderViewModel(this IEnumerable<CartItemModel> cartItems)
        {
            return cartItems.Select(ci => ci.ToOrderViewModel());
        }

        public static ICollection<OrderItem> ToEntity(this IEnumerable<OrderItemViewModel> orderItemViewModels)
        {
            return orderItemViewModels.Select(o => o.ToEntity()).ToList();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OnlineStore.Extention;
using OnlineStore.Models;
using OnlineStoreServices.Managers;

namespace OnlineStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartManager _cartManager;
        private readonly IOrderManager _orderManager;

        public OrderController(ICartManager cartManager, IOrderManager orderManager)
        {
            _cartManager = cartManager;
            _orderManager = orderManager;
        }

        public IActionResult ViewOrderHistory()
        {
            var userId = HttpContext.Session.GetId();
            var order = _orderManager.GetAllOrders(userId).ToViewModel();
            return View(order);
        }

        public IActionResult ViewOrderDetailsById(int specific)
        {
            var order = _orderManager.GetOrderbyId(specific).ToViewModel();
            return View(order);
        }

        public IActionResult PurchaseOrder()
        {
            var userId = HttpContext.Session.GetId();
            var cart = _cartManager.GetUserCart(userId).ToModel();
            if(cart.Items == null)
            {
                return View("Cart", "ViewCart");
            }
            if (ModelState.IsValid)
            {
                var newOrder = new OrderViewModel
                {
                    UserId = userId,
                    CreatedDate = DateTime.Now,
                    OrderTotalSum = cart.OrderTotal,
                    OrderedItems = cart.Items.ToOrderViewModel(),
                };

                _orderManager.AddOrdertoDb(newOrder.ToEntity());
                _cartManager.ClearCart(userId);
                return RedirectToAction(nameof(ViewOrderHistory));
            }
            return View("Cart", "ViewCart");
        }
    }
}

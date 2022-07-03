using Microsoft.AspNetCore.Mvc;
using OnlineStore.Extention;
using OnlineStore.Models;
using OnlineStoreServices.Managers;

namespace OnlineStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartManager _cartManager;

        public CartController(ICartManager cartManager)
        {
            _cartManager = cartManager;
        }

        public IActionResult ViewCart()
        {
            var UserId = HttpContext.Session.GetInt32("id");
            var cart = new CartViewModel();
            if (UserId.HasValue)
            {
                cart.Items = _cartManager.GetCartItems(UserId.Value).Select(i => i.ToItemModel());
                return View(cart);
            }
            return BadRequest();
        }
    }
}


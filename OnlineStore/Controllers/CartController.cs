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
            var UserId = HttpContext.Session.GetId();
            var cart = new CartViewModel();
            cart.Items = _cartManager.GetCartItems(UserId).ToModel();
            return View(cart);
        }

        public IActionResult AddToCart(int product)
        {
            var UserId = HttpContext.Session.GetId();
            _cartManager.AddCartItem(UserId, product);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}


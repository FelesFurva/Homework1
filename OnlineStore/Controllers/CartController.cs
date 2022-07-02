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

        public IActionResult ViewCart(int specific)
        {
            var cart = new CartViewModel();
            cart.Items = _cartManager.GetCartItems(specific).Select(i => i.ToItemModel());
            return View(cart);
        }


    }
}


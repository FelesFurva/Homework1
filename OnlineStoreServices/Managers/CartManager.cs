using DataAccess.Context;
using DataAccess.Context.Entity;
using Microsoft.EntityFrameworkCore;

namespace OnlineStoreServices.Managers
{
    public class CartManager : ICartManager
    {
        private readonly WebShopDBContext _webShopDB;

        public CartManager(WebShopDBContext webShopDB)
        {
            _webShopDB = webShopDB;
        }

        public Cart GetCart(int userId)
        {
            var cart = _webShopDB.Cart.Include(c => c.Items).ThenInclude(i => i.Product).SingleOrDefault(c => c.UserId == userId);
            return cart;
        }

        public IEnumerable<CartItem> GetCartItems(int userId)
        {
            var cart = _webShopDB.Cart.Include(c => c.Items).ThenInclude(i => i.Product).SingleOrDefault(c => c.UserId == userId);
            var cartItems = cart.Items.Where(c => c.CartId == cart.CartId);
            return cartItems;
        }

        public void AddCartItem(int UserId, int ProductId)
        {
            var cart = _webShopDB.Cart.Include(c => c.Items).SingleOrDefault(c => c.UserId == UserId);
            var cartItemList = cart.Items;
            var cartItem = cartItemList.SingleOrDefault(i => i.ProductId == ProductId);
            if (cartItem == null)
            {
                var newCartItem = new CartItem
                {
                    CartId = cart.CartId,
                    ProductId = ProductId,
                    Quantity = 1,
                };

                _webShopDB.Add(newCartItem);
                _webShopDB.SaveChanges();
            }
            else
            {
                cartItem.Quantity += 1;
                _webShopDB.SaveChanges();
            }
        }
    }
}

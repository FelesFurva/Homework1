using DataAccess.Context;
using DataAccess.Context.Entity;
using Microsoft.EntityFrameworkCore;

namespace OnlineStoreServices.Managers
{
    public class CartManager : ICartManager
    {
        private readonly IWebShop _webShopDB;

        public CartManager(IWebShop webShopDB)
        {
            _webShopDB = webShopDB;
        }

        public void AddCartToDB(int userId)
        {
            var cart = new Cart
            {
                UserId = userId,
            };

            _webShopDB.Cart.Add(cart);
            _webShopDB.SaveChanges();
        }

        public IEnumerable<CartItem> GetCartItems(int userId)
        {
            var cart = _webShopDB.Cart.Include(c => c.Items).ThenInclude(i => i.Product).SingleOrDefault(c => c.UserId == userId);
            var cartItems = cart.Items.Where(c => c.CartId == cart.CartId);
            return cartItems;
        }

        public Cart GetUserCart(int userId)
        {
            var cart = _webShopDB.Cart.Include(c => c.Items).ThenInclude(i => i.Product).SingleOrDefault(c => c.UserId == userId);
            return cart;
        }

        public void AddCartItem(int UserId, int ProductId, int quantity = 1)
        {
            var cart = _webShopDB.Cart.Include(c => c.Items).SingleOrDefault(c => c.UserId == UserId);
            var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == ProductId);
            if (cartItem == null)
            {
                var newCartItem = new CartItem
                {
                    CartId = cart.CartId,
                    ProductId = ProductId,
                    Quantity = quantity,
                };
                _webShopDB.CartItem.Add(newCartItem);
                _webShopDB.SaveChanges();
            }
            else
            {
                cartItem.Quantity += quantity;
                _webShopDB.SaveChanges();
            }
        }

        public void RemoveCartItem(int userId, int ItemId)
        {
            var cart = GetCartItems(userId);
            var cartItem = cart.SingleOrDefault(i => i.CartItemId == ItemId);
            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity -= 1;
                _webShopDB.SaveChanges();
            }
            else
            {
                _webShopDB.CartItem.Remove(cartItem);
                _webShopDB.SaveChanges();
            }
        }

        public void ClearCart(int userId)
        {
            var toBeRemoved = GetCartItems(userId);
            _webShopDB.CartItem.RemoveRange(toBeRemoved);
            _webShopDB.SaveChanges();
        }
    }
}

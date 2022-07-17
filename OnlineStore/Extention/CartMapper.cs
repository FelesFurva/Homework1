using DataAccess.Context.Entity;
using OnlineStore.Models;

namespace OnlineStore.Extention
{
    public class CartMapper
    {
        public CartViewModel ToModel(Cart cart)
        {
            List<CartItemModel> cartItems = new List<CartItemModel>();
            var cartModel = new CartViewModel
            {
                UserId = cart.UserId,
                CartId = cart.CartId,
                Items = cartItems
            };
            return cartModel;
        }
    }
}

using DataAccess.Context.Entity;
using OnlineStore.Models;

namespace OnlineStore.Extention
{
    public static class CartExtension
    {
        public static CartViewModel ToModel(this Cart cart)
        {
            var cartModel = new CartViewModel
            {
                UserId = cart.UserId,
                CartId = cart.CartId,
                Items = cart.Items.ToModel(),
            };
            return cartModel;
        }

        public static CartItemModel ToItemModel(this CartItem cartItem)
        {
            var cartItemModel = new CartItemModel
            {
                CartItemId = cartItem.CartItemId,
                Quantity = cartItem.Quantity,
                DateCreated = cartItem.DateCreated,
                CartId = cartItem.CartId,
                ProductId = cartItem.ProductId,
                Product = cartItem.Product.ToModel(),
            };
            return cartItemModel;
        }

        public static IEnumerable<CartItemModel> ToModel(this IEnumerable<CartItem> cartItems)
        {
            return cartItems.Select(ci => ci.ToItemModel());
        }
    }
}

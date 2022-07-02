using DataAccess.Context.Entity;
using OnlineStore.Models;

namespace OnlineStore.Extention
{
    public static class CartItemExtension
    {
        public static CartItemModel ToItemModel(this CartItem cartItem)
        {
            var cartItemModel = new CartItemModel
            {
                CartItemId = cartItem.CartItemId,
                Quantity = cartItem.Quantity,
                DateCreated = cartItem.DateCreated,
                CartId = cartItem.CartId,
                ProductId = cartItem.ProductId,
                Product = cartItem.Product,
            };
            return cartItemModel;
        }
    }
}

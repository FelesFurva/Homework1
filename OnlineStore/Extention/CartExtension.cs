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
            };
            return cartModel;
        }
    }
}

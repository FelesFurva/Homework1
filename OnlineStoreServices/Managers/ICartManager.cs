using DataAccess.Context.Entity;

namespace OnlineStoreServices.Managers
{
    public interface ICartManager
    {
        Cart GetCart(int userId);
        void AddCartItem(int UserId, int ProductId);
        IEnumerable<CartItem> GetCartItems(int userId);
    }
}

using DataAccess.Context.Entity;

namespace OnlineStoreServices.Managers
{
    public interface ICartManager
    {
        void AddCartItem(int UserId, int ProductId);
        IEnumerable<CartItem> GetCartItems(int userId);
        Cart GetUserCart(int userId);
        void ClearCart(int userId);
    }
}

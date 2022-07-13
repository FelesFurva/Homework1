using DataAccess.Context.Entity;

namespace OnlineStoreServices.Managers
{
    public interface ICartManager
    {
        void AddCartItem(int UserId, int ProductId, int quantity = 1);
        IEnumerable<CartItem> GetCartItems(int userId);
        Cart GetUserCart(int userId);
        void ClearCart(int userId);
        void RemoveCartItem(int userId, int ItemId);
    }
}

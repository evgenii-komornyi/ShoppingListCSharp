using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.CartNS;

namespace ShoppingList.Repository.CartNS
{
    public interface ICart
    {
        Cart Create(Cart cart);
        Cart ReadById(CartFindRequest request);
        bool ToCart(Product product, Cart cart, int quantity);
        bool RemoveFromCart(long ProductId, long CartId);
        bool Clear(long CartId);
    }
}

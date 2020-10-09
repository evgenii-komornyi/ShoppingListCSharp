using ShoppingList.DataModel.Request.CartNS;
using ShoppingList.DataModel.Response.CartNS;

namespace ShoppingList.Service.CartNS
{
    public interface ICartService
    {
        CartCreateResponse CreateCart(CartCreateRequest request);
        CartFindResponse FindCartById(CartFindRequest request);
        AddUpdateCartResponse AddToCart(AddUpdateCartRequest request);
        RemoveProductFromCartResponse RemoveFromCart(RemoveProductFromCartRequest request);
        CartClearResponse ClearCart(CartClearRequest request);
    }
}
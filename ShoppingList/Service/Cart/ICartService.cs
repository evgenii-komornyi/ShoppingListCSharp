using ShoppingList.DataModel;
using ShoppingList.DataModel.Request;
using ShoppingList.DataModel.Request.Cart;
using ShoppingList.DataModel.Response;
using ShoppingList.DataModel.Response.Cart;

namespace ShoppingList.Service
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
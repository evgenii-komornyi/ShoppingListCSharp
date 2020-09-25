using ShoppingList.DataModel;

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
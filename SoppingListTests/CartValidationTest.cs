using ShoppingList;
using ShoppingList.DataModel;
using ShoppingList.Validation.Cart;
using ShoppingList.Validation.Errors;
using Xunit;

namespace ShoppingListTests
{
    public class CartValidationTest
    {
        [Theory]
        [InlineData(null, 1 ,CartValidationErrors.EMPTY_CART_ID)]
        public void ShouldReturnErrorCodes(long cartId, long userId,  CartValidationErrors expectedError)
        {
            AddProductToCartValidation AddProductToCartValidation = new AddProductToCartValidation();
            CartCreateRequestValidation CartCreateRequestValidation = new CartCreateRequestValidation();
            CartFindRequestValidation CartFindRequestValidation = new CartFindRequestValidation();
            CartRemoveRequestValidation CartRemoveRequestValidation = new CartRemoveRequestValidation();
            RemoveFromCartRequestValidation RemoveFromCartRequestValidation = new RemoveFromCartRequestValidation();
            CartClearRequestValidation CartClearRequestValidation = new CartClearRequestValidation();

            CartValidation _validation = new CartValidation(AddProductToCartValidation, CartCreateRequestValidation, 
                                                            CartFindRequestValidation, CartRemoveRequestValidation, RemoveFromCartRequestValidation, CartClearRequestValidation);

            var request = new CartCreateRequest
            {
                UserId = userId,
                CartId = cartId
            };

            var listErrors = _validation.CartCreateRequestValidation.Validate(request);

            foreach (var error in listErrors)
            {
                Assert.Equal(expectedError, error);
            }
        }
    }
}

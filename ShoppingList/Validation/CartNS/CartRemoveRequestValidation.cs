using ShoppingList.DataModel;
using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.Validation.CartNS
{
    public class CartRemoveRequestValidation : Validatable<Cart, CartValidationErrors>
    {
        public List<CartValidationErrors> Validate(Cart cart)
        {
            List<CartValidationErrors> allErrors = new List<CartValidationErrors>();

            allErrors.AddRange(validateNotEmptyCart(cart));

            return allErrors;
        }

        private List<CartValidationErrors> validateNotEmptyCart(Cart cart)
        {
            List<CartValidationErrors> errorsList = new List<CartValidationErrors>();

            if (cart.ProductsCarts.Count != 0)
            {
                errorsList.Add(CartValidationErrors.CART_NOT_EMPTY);
            }

            return errorsList;
        }
    }
}

using ShoppingList.DataModel.Request.Cart;
using ShoppingList.Validation.Errors;
using System;
using System.Collections.Generic;

namespace ShoppingList.Validation.Cart
{
    public class RemoveFromCartRequestValidation : Validatable<RemoveProductFromCartRequest, CartValidationErrors>
    {
        public List<CartValidationErrors> Validate(RemoveProductFromCartRequest request)
        {
            List<CartValidationErrors> allErrors = new List<CartValidationErrors>();

            allErrors.AddRange(validateCartId(request.CartId));
            allErrors.AddRange(validateProductId(request.ProductId));

            return allErrors;
        }

        private List<CartValidationErrors> validateCartId(long cartId)
        {
            List<CartValidationErrors> errorsList = new List<CartValidationErrors>();

            if (cartId == null)
            {
                errorsList.Add(CartValidationErrors.EMPTY_CART_ID);
            }
            return errorsList;
        }

        private List<CartValidationErrors> validateProductId(long productId)
        {
            List<CartValidationErrors> errorsList = new List<CartValidationErrors>();

            if (productId == null)
            {
                errorsList.Add(CartValidationErrors.EMPTY_PRODUCT_ID);
            }
            return errorsList;
        }
    }
}
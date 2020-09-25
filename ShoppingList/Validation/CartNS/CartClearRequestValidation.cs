using ShoppingList.DataModel.Request.CartNS;
using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.Validation.CartNS
{
    public class CartClearRequestValidation : Validatable<CartClearRequest, CartValidationErrors>
    {
        public List<CartValidationErrors> Validate(CartClearRequest request)
        {
            List<CartValidationErrors> allErrors = new List<CartValidationErrors>();

            allErrors.AddRange(validateIDField(request.CartId));

            return allErrors;
        }

        private List<CartValidationErrors> validateIDField(long id)
        {
            List<CartValidationErrors> errorsList = new List<CartValidationErrors>();

            if (id == null)
            {
                errorsList.Add(CartValidationErrors.EMPTY_CART_ID);
            }

            return errorsList;
        }
    }
}

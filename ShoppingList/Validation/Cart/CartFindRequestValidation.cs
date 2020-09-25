using ShoppingList.DataModel;
using ShoppingList.Validation;
using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList
{
    public class CartFindRequestValidation : Validatable<CartFindRequest, CartValidationErrors>
    {
        public List<CartValidationErrors> Validate(CartFindRequest findFieldRequest)
        {
            List<CartValidationErrors> allErrors = new List<CartValidationErrors>();

            allErrors.AddRange(validateIDField(findFieldRequest.CartId));

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

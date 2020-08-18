using ShoppingList.DataModel.Request.Cart;
using ShoppingList.Validation;
using ShoppingList.Validation.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    public class CartCreateRequestValidation : Validatable<CartCreateRequest, CartValidationErrors>
    {
        public List<CartValidationErrors> Validate(CartCreateRequest createFieldRequest)
        {
            List<CartValidationErrors> allErrors = new List<CartValidationErrors>();

            allErrors.AddRange(validateNameField(createFieldRequest.CartId));

            return allErrors;
        }

        private List<CartValidationErrors> validateNameField(long id)
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

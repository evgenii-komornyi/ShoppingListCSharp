using ShoppingList.DataModel;
using ShoppingList.Validation;
using ShoppingList.Validation.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
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

            if (cart.Products.Count != 0)
            {
                errorsList.Add(CartValidationErrors.CART_NOT_EMPTY);
            }

            return errorsList;
        }
    }
}

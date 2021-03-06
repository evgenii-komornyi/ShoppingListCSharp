﻿using ShoppingList.DataModel.Request.CartNS;
using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.Validation.CartNS
{
    public class AddProductToCartValidation : Validatable<AddUpdateCartRequest, CartValidationErrors>
    {
        public List<CartValidationErrors> Validate(AddUpdateCartRequest request)
        {
            List<CartValidationErrors> allErrors = new List<CartValidationErrors>();

            allErrors.AddRange(ValidateProductId(request.ProductId));
            allErrors.AddRange(ValidateCartId(request.CartId));

            return allErrors;
        }

        private List<CartValidationErrors> ValidateProductId(long productId)
        {
            List<CartValidationErrors> errorsList = new List<CartValidationErrors>();

            if (productId == null)
            {
                errorsList.Add(CartValidationErrors.EMPTY_PRODUCT_ID);
            }
            return errorsList;
        }

        private List<CartValidationErrors> ValidateCartId(long cartId)
        {
            List<CartValidationErrors> errorsList = new List<CartValidationErrors>();

            if (cartId == null)
            {
                errorsList.Add(CartValidationErrors.EMPTY_CART_ID);
            }
            return errorsList;
        }

/*        private List<CartValidationErrors> ValidateProductInCartExist(ICollection<ProductCart> productsList, Product product)
        {
            List<CartValidationErrors> errorsList = new List<CartValidationErrors>();

            if (productsList.Contains(product))
            {
                errorsList.Add(CartValidationErrors.DUPLICATE_ENTRY);
            }
            return errorsList;
        }*/
    }
}

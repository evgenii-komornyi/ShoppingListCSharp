using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Validation.Cart
{
    public class CartValidation
    {
        public AddProductToCartValidation AddProductToCartValidation;
        public CartCreateRequestValidation CartCreateRequestValidation;
        public CartFindRequestValidation CartFindRequestValidation;
        public CartRemoveRequestValidation CartRemoveRequestValidation;
        public RemoveFromCartRequestValidation RemoveFromCartRequestValidation;
        public CartClearRequestValidation CartClearRequestValidation;

        public CartValidation(AddProductToCartValidation addProductToCartValidation, CartCreateRequestValidation cartCreateRequestValidation,
                              CartFindRequestValidation cartFindRequestValidation, CartRemoveRequestValidation cartRemoveRequestValidation,
                              RemoveFromCartRequestValidation removeFromCartRequestValidation, CartClearRequestValidation cartClearRequestValidation)
        {
            AddProductToCartValidation = addProductToCartValidation;
            CartCreateRequestValidation = cartCreateRequestValidation;
            CartFindRequestValidation = cartFindRequestValidation;
            CartRemoveRequestValidation = cartRemoveRequestValidation;
            RemoveFromCartRequestValidation = removeFromCartRequestValidation;
            CartClearRequestValidation = cartClearRequestValidation;
        }
    }
}

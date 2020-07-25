using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Validation.Errors
{
    public enum CartValidationErrors
    {
        EMPTY_ID,
        CART_NOT_EMPTY,
        DUPLICATE_ENTRY,
        CART_NOT_EXIST,
        PRODUCT_NOT_EXIST
    }
}

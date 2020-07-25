using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Validation.Errors
{
    public enum ProductValidationErrors
    {
        EMPTY_NAME,
        EMPTY_PRICE,
        EMPTY_CATEGORY,
        NAME_LENGTH_VIOLATION,
        DUPLICATE_NAME,
        NEGATIVE_OR_ZERO_PRICE,
        DISCOUNT_APPLICATION_LIMIT_VIOLATION,
        INVALID_DISCOUNT_RANGE,
        DESCIPTION_LENGTH_VIOLATION,
        NO_SEARCH_CRITERIA,
        CONFLICT_SEARCH_PARAMS,
        NO_UPDATE_CRITERIA,
        CONFLICT_UPDATE_PARAMS,
        EMPTY_ID
    }
}

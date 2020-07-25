using ShoppingList.Validation;
using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.DataModel.Response.Cart
{
    public abstract class CartBasicResponse
    {
        public List<CartValidationErrors> ValidationErrors { get; set; }
        public List<DatabaseErrors> DBErrors { get; set; }

        public bool hasValidationErrors()
        {
            return (ValidationErrors != null && ValidationErrors.Count != 0);
        }

        public bool hasDBErrors()
        {
            return (DBErrors != null && DBErrors.Count != 0);
        }
    }
}

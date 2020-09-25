using DataTransferObjects.ProductDTO;
using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace DataTransferObjects.CartDTO
{
    public class CartBasicDTO
    {
        public Status status { get; set; }
        public List<CartValidationErrors> validationErrors { get; set; }
        public List<DatabaseErrors> dbErrors { get; set; }
    }
}

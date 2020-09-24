using DataTransferObjects.ProductDTO;
using ShoppingList.Validation;
using ShoppingList.Validation.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.CartDTO
{
    public class CartBasicDTO
    {
        public Status status { get; set; }
        public List<CartValidationErrors> validationErrors { get; set; }
        public List<DatabaseErrors> dbErrors { get; set; }
    }
}

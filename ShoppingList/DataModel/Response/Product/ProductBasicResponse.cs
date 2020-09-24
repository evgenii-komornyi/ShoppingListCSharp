using ShoppingList.Validation;
using ShoppingList.Validation.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel.Response.Product
{
    public class ProductBasicResponse
    {
        public List<ProductValidationErrors> ValidationErrors { get; set; }
        public List<DatabaseErrors> DBErrors { get; set; }

        public bool HasValidationErrors()
        {
            return (ValidationErrors != null && ValidationErrors.Count != 0);
        }
        
        public bool HasDBErrors()
        {
            return (DBErrors != null && DBErrors.Count != 0);
        }
    }
}

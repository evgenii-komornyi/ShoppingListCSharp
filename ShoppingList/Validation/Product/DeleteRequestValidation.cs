using ShoppingList.DataModel.Request.Product;
using ShoppingList.Validation.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Validation.Product
{
    public class DeleteRequestValidation
    {
        public List<ProductValidationErrors> ValidateDeleteRequest(ProductDeleteRequest deleteRequest)
        {
            List<ProductValidationErrors> allErrors = new List<ProductValidationErrors>();

            if (deleteRequest.Id == null)
            {
                allErrors.Add(ProductValidationErrors.EMPTY_ID);
            }

            return allErrors;
        }
    }
}

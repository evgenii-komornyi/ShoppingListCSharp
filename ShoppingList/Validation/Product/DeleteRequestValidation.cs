using ShoppingList.DataModel;
using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.Validation.Product
{
    public class DeleteRequestValidation : Validatable<ProductDeleteRequest, ProductValidationErrors>
    {
        public List<ProductValidationErrors> Validate(ProductDeleteRequest deleteRequest)
        {
            List<ProductValidationErrors> allErrors = new List<ProductValidationErrors>();

            if (deleteRequest.Id == null)
            {
                allErrors.Add(ProductValidationErrors.Empty_id);
            }

            return allErrors;
        }
    }
}

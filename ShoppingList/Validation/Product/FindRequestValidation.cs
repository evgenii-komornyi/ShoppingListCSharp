using ShoppingList.DataModel;
using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.Validation.Product
{
    public class FindRequestValidation : Validatable<ProductFindRequest, ProductValidationErrors>
    {
        public List<ProductValidationErrors> Validate(ProductFindRequest findFieldRequest)
        {
            return new List<ProductValidationErrors>(ValidateSearchCriteria(findFieldRequest));
        }

        private List<ProductValidationErrors> ValidateSearchCriteria(ProductFindRequest searchCriteria)
        {
            List<ProductValidationErrors> allErrors = new List<ProductValidationErrors>();

            if (searchCriteria.ProductId == null
                    && searchCriteria.Name == null
                    && searchCriteria.Category_Id == null)
            {
                allErrors.Add(ProductValidationErrors.No_search_criteria);
            }

            if (searchCriteria.ProductId != null
                    && searchCriteria.Name != null
                    && searchCriteria.Category_Id != null)
            {
                allErrors.Add(ProductValidationErrors.Conflict_params);
            }
            return allErrors;
        }
    }
}

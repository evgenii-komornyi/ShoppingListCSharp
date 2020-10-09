using ShoppingList.DataModel.Request.AddressNS;
using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.Validation.AddressNS
{
    public class AddressCreateRequestValidation : Validatable<AddressCreateRequest, AddressValidationErrors>
    {
        public List<AddressValidationErrors> Validate(AddressCreateRequest request)
        {
            List<AddressValidationErrors> allErrors = new List<AddressValidationErrors>();

            allErrors.AddRange(validateCountryLength(request.Country));

            return allErrors;
        }

        private List<AddressValidationErrors> validateCountryLength(string country)
        {
            List<AddressValidationErrors> errorsList = new List<AddressValidationErrors>();

            if (country.Length < 1 && country.Length > 50)
            {
                errorsList.Add(AddressValidationErrors.Country_Length_Violation);
            }

            return errorsList;
        }
    }
}

using ShoppingList.DataModel.Request.UserNS;
using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.Validation.UserNS
{
    public class UserCreateRequestValidation : Validatable<UserCreateRequest, UserValidationErrors>
    {
        public List<UserValidationErrors> Validate(UserCreateRequest request)
        {
            List<UserValidationErrors> allErrors = new List<UserValidationErrors>();

            allErrors.AddRange(validateFirstName(request.FirstName));

            return allErrors;
        }

        private List<UserValidationErrors> validateFirstName(string firstName)
        {
            var errorsList = new List<UserValidationErrors>();

            if (firstName.Length == 0 || firstName == null)
            {
                errorsList.Add(UserValidationErrors.Empty_FirstName);
            }

            if (firstName.Length < 2 || firstName.Length > 15)
            {
                errorsList.Add(UserValidationErrors.FirstName_LengthViolation);
            }
            return errorsList;
        }
    }
}
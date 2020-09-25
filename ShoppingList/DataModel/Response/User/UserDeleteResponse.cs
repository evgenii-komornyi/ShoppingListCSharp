using ShoppingList.Validation;
using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.DataModel
{
    public class UserDeleteResponse : UserBasicResponse
    {
        public bool HasDeleted { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UserDeleteResponse response &&
                   EqualityComparer<List<UserValidationErrors>>.Default.Equals(ValidationErrors, response.ValidationErrors) &&
                   EqualityComparer<List<DatabaseErrors>>.Default.Equals(DBErrors, response.DBErrors) &&
                   HasDeleted == response.HasDeleted;
        }

        public override int GetHashCode()
        {
            int hashCode = -938847455;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<UserValidationErrors>>.Default.GetHashCode(ValidationErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<DatabaseErrors>>.Default.GetHashCode(DBErrors);
            hashCode = hashCode * -1521134295 + HasDeleted.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{{nameof(HasDeleted)}={HasDeleted.ToString()}, {nameof(ValidationErrors)}={ValidationErrors}, {nameof(DBErrors)}={DBErrors}}}";
        }
    }
}

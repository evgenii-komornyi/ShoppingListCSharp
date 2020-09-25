using ShoppingList.Validation;
using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.DataModel
{
    public class UserUpdateResponse : UserBasicResponse
    {
        public User UpdatedUser { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UserUpdateResponse response &&
                   EqualityComparer<List<UserValidationErrors>>.Default.Equals(ValidationErrors, response.ValidationErrors) &&
                   EqualityComparer<List<DatabaseErrors>>.Default.Equals(DBErrors, response.DBErrors) &&
                   EqualityComparer<User>.Default.Equals(UpdatedUser, response.UpdatedUser);
        }

        public override int GetHashCode()
        {
            int hashCode = -401550584;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<UserValidationErrors>>.Default.GetHashCode(ValidationErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<DatabaseErrors>>.Default.GetHashCode(DBErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(UpdatedUser);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{{nameof(UpdatedUser)}={UpdatedUser}, {nameof(ValidationErrors)}={ValidationErrors}, {nameof(DBErrors)}={DBErrors}}}";
        }
    }
}

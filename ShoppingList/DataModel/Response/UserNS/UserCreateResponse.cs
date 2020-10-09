using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.DataModel.Response.UserNS
{
    public class UserCreateResponse : UserBasicResponse
    {
        public User User { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UserCreateResponse response &&
                   EqualityComparer<List<UserValidationErrors>>.Default.Equals(ValidationErrors, response.ValidationErrors) &&
                   EqualityComparer<List<DatabaseErrors>>.Default.Equals(DBErrors, response.DBErrors) &&
                   EqualityComparer<User>.Default.Equals(User, response.User);
        }

        public override int GetHashCode()
        {
            int hashCode = 1972486663;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<UserValidationErrors>>.Default.GetHashCode(ValidationErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<DatabaseErrors>>.Default.GetHashCode(DBErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(User);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{{nameof(User)}={User}, {nameof(ValidationErrors)}={ValidationErrors}, {nameof(DBErrors)}={DBErrors}}}";
        }
    }
}

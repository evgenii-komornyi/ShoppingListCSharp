using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.DataModel.Response.UserNS
{
    public class UserFindResponse : UserBasicResponse
    {
        public User FoundUser { get; set; }
        public List<User> FoundUsers { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UserFindResponse response &&
                   EqualityComparer<List<UserValidationErrors>>.Default.Equals(ValidationErrors, response.ValidationErrors) &&
                   EqualityComparer<List<DatabaseErrors>>.Default.Equals(DBErrors, response.DBErrors) &&
                   EqualityComparer<User>.Default.Equals(FoundUser, response.FoundUser) &&
                   EqualityComparer<List<User>>.Default.Equals(FoundUsers, response.FoundUsers);
        }

        public override int GetHashCode()
        {
            int hashCode = -902714602;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<UserValidationErrors>>.Default.GetHashCode(ValidationErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<DatabaseErrors>>.Default.GetHashCode(DBErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(FoundUser);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<User>>.Default.GetHashCode(FoundUsers);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{{nameof(FoundUser)}={FoundUser}, {nameof(FoundUsers)}={FoundUsers}, {nameof(ValidationErrors)}={ValidationErrors}, {nameof(DBErrors)}={DBErrors}}}";
        }
    }
}

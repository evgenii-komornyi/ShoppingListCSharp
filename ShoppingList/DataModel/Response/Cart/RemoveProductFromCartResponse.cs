using ShoppingList.Validation;
using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.DataModel
{
    public class RemoveProductFromCartResponse : CartBasicResponse
    {
        public bool HasRemoved { get; set; }

        public override bool Equals(object obj)
        {
            return obj is RemoveProductFromCartResponse response &&
                   EqualityComparer<List<CartValidationErrors>>.Default.Equals(ValidationErrors, response.ValidationErrors) &&
                   EqualityComparer<List<DatabaseErrors>>.Default.Equals(DBErrors, response.DBErrors) &&
                   HasRemoved == response.HasRemoved;
        }

        public override int GetHashCode()
        {
            int hashCode = 1154070758;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<CartValidationErrors>>.Default.GetHashCode(ValidationErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<DatabaseErrors>>.Default.GetHashCode(DBErrors);
            hashCode = hashCode * -1521134295 + HasRemoved.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{{nameof(HasRemoved)}={HasRemoved.ToString()}, {nameof(ValidationErrors)}={ValidationErrors}, {nameof(DBErrors)}={DBErrors}}}";
        }


    }
}

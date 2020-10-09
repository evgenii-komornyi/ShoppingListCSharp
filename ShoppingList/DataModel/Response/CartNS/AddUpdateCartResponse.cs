using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.DataModel.Response.CartNS
{
    public class AddUpdateCartResponse : CartBasicResponse
    {
        public bool HasAdded { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AddUpdateCartResponse response &&
                   EqualityComparer<List<CartValidationErrors>>.Default.Equals(ValidationErrors, response.ValidationErrors) &&
                   EqualityComparer<List<DatabaseErrors>>.Default.Equals(DBErrors, response.DBErrors) &&
                   HasAdded == response.HasAdded;
        }

        public override int GetHashCode()
        {
            int hashCode = -1491536292;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<CartValidationErrors>>.Default.GetHashCode(ValidationErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<DatabaseErrors>>.Default.GetHashCode(DBErrors);
            hashCode = hashCode * -1521134295 + HasAdded.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{{nameof(HasAdded)}={HasAdded.ToString()}, {nameof(ValidationErrors)}={ValidationErrors}, {nameof(DBErrors)}={DBErrors}}}";
        }
    }
}

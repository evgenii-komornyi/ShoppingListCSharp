using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.DataModel.Response.AddressNS
{
    public class AddressCreateResponse : AddressBasicResponse
    {
        public List<Address> Addresses { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AddressCreateResponse response &&
                   EqualityComparer<List<AddressValidationErrors>>.Default.Equals(ValidationErrors, response.ValidationErrors) &&
                   EqualityComparer<List<DatabaseErrors>>.Default.Equals(DBErrors, response.DBErrors) &&
                   EqualityComparer<List<Address>>.Default.Equals(Addresses, response.Addresses);
        }

        public override int GetHashCode()
        {
            int hashCode = 1263789944;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<AddressValidationErrors>>.Default.GetHashCode(ValidationErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<DatabaseErrors>>.Default.GetHashCode(DBErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Address>>.Default.GetHashCode(Addresses);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{{nameof(Addresses)}={Addresses}, {nameof(ValidationErrors)}={ValidationErrors}, {nameof(DBErrors)}={DBErrors}}}";
        }
    }
}

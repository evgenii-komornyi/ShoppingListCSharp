using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.DataModel.Response.CartNS
{
    public class CartFindResponse : CartBasicResponse
    {
        public Cart Cart { get; set; }
        public decimal Amount { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CartFindResponse response &&
                   EqualityComparer<List<CartValidationErrors>>.Default.Equals(ValidationErrors, response.ValidationErrors) &&
                   EqualityComparer<List<DatabaseErrors>>.Default.Equals(DBErrors, response.DBErrors) &&
                   EqualityComparer<Cart>.Default.Equals(Cart, response.Cart) &&
                   Amount == response.Amount;
        }

        public override int GetHashCode()
        {
            int hashCode = 236076717;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<CartValidationErrors>>.Default.GetHashCode(ValidationErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<DatabaseErrors>>.Default.GetHashCode(DBErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<Cart>.Default.GetHashCode(Cart);
            hashCode = hashCode * -1521134295 + Amount.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{{nameof(Cart)}={Cart}, {nameof(Amount)}={Amount.ToString()}, {nameof(ValidationErrors)}={ValidationErrors}, {nameof(DBErrors)}={DBErrors}}}";
        }
    }
}

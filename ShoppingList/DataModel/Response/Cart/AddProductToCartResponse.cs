using ShoppingList.DataModel.Response.Cart;
using ShoppingList.Validation;
using ShoppingList.Validation.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel
{
    public class AddProductToCartResponse : CartBasicResponse
    {
        public Cart Cart { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AddProductToCartResponse response &&
                   EqualityComparer<List<CartValidationErrors>>.Default.Equals(ValidationErrors, response.ValidationErrors) &&
                   EqualityComparer<List<DatabaseErrors>>.Default.Equals(DBErrors, response.DBErrors) &&
                   EqualityComparer<Cart>.Default.Equals(Cart, response.Cart);
        }

        public override int GetHashCode()
        {
            int hashCode = -1388259932;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<CartValidationErrors>>.Default.GetHashCode(ValidationErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<DatabaseErrors>>.Default.GetHashCode(DBErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<Cart>.Default.GetHashCode(Cart);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{{nameof(Cart)}={Cart}, {nameof(ValidationErrors)}={ValidationErrors}, {nameof(DBErrors)}={DBErrors}}}";
        }


    }
}

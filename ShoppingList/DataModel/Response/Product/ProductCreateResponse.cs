using ShoppingList.Validation;
using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.DataModel
{
    public class ProductCreateResponse : ProductBasicResponse
    {
        public Product Product { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProductCreateResponse response &&
                   EqualityComparer<List<ProductValidationErrors>>.Default.Equals(ValidationErrors, response.ValidationErrors) &&
                   EqualityComparer<List<DatabaseErrors>>.Default.Equals(DBErrors, response.DBErrors) &&
                   EqualityComparer<Product>.Default.Equals(Product, response.Product);
        }

        public override int GetHashCode()
        {
            int hashCode = -201440511;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<ProductValidationErrors>>.Default.GetHashCode(ValidationErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<DatabaseErrors>>.Default.GetHashCode(DBErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<Product>.Default.GetHashCode(Product);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{{nameof(Product)}={Product}, {nameof(ValidationErrors)}={ValidationErrors}, {nameof(DBErrors)}={DBErrors}}}";
        }
    }
}

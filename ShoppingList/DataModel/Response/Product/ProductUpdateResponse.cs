using ShoppingList.Validation;
using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.DataModel
{
    public class ProductUpdateResponse : ProductBasicResponse
    {
        public Product UpdatedProduct { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProductUpdateResponse response &&
                   EqualityComparer<List<ProductValidationErrors>>.Default.Equals(ValidationErrors, response.ValidationErrors) &&
                   EqualityComparer<List<DatabaseErrors>>.Default.Equals(DBErrors, response.DBErrors) &&
                   EqualityComparer<Product>.Default.Equals(UpdatedProduct, response.UpdatedProduct);
        }

        public override int GetHashCode()
        {
            int hashCode = -474314924;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<ProductValidationErrors>>.Default.GetHashCode(ValidationErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<DatabaseErrors>>.Default.GetHashCode(DBErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<Product>.Default.GetHashCode(UpdatedProduct);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{{nameof(UpdatedProduct)}={UpdatedProduct}, {nameof(ValidationErrors)}={ValidationErrors}, {nameof(DBErrors)}={DBErrors}}}";
        }
    }
}

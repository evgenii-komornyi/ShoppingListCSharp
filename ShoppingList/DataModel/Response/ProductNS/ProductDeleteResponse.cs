using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace ShoppingList.DataModel.Response.ProductNS
{
    public class ProductDeleteResponse : ProductBasicResponse
    {
        public bool HasDeleted { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProductDeleteResponse response &&
                   EqualityComparer<List<ProductValidationErrors>>.Default.Equals(ValidationErrors, response.ValidationErrors) &&
                   EqualityComparer<List<DatabaseErrors>>.Default.Equals(DBErrors, response.DBErrors) &&
                   HasDeleted == response.HasDeleted;
        }

        public override int GetHashCode()
        {
            int hashCode = 1635874977;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<ProductValidationErrors>>.Default.GetHashCode(ValidationErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<DatabaseErrors>>.Default.GetHashCode(DBErrors);
            hashCode = hashCode * -1521134295 + HasDeleted.GetHashCode();
            return hashCode;
        }
    }
}

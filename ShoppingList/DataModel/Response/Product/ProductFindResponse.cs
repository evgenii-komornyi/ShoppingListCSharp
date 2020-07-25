using ShoppingList.DataModel.Response.Product;
using ShoppingList.Validation;
using ShoppingList.Validation.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel
{
    public class ProductFindResponse : ProductBasicResponse
    {
        public Product FoundProduct { get; set; }
        public List<Product> ListOfFoundProducts { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProductFindResponse response &&
                   EqualityComparer<List<ProductValidationErrors>>.Default.Equals(ValidationErrors, response.ValidationErrors) &&
                   EqualityComparer<List<DatabaseErrors>>.Default.Equals(DBErrors, response.DBErrors) &&
                   EqualityComparer<Product>.Default.Equals(FoundProduct, response.FoundProduct) &&
                   EqualityComparer<List<Product>>.Default.Equals(ListOfFoundProducts, response.ListOfFoundProducts);
        }

        public override int GetHashCode()
        {
            int hashCode = -2058947225;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<ProductValidationErrors>>.Default.GetHashCode(ValidationErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<DatabaseErrors>>.Default.GetHashCode(DBErrors);
            hashCode = hashCode * -1521134295 + EqualityComparer<Product>.Default.GetHashCode(FoundProduct);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Product>>.Default.GetHashCode(ListOfFoundProducts);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{{nameof(FoundProduct)}={FoundProduct}, {nameof(ListOfFoundProducts)}={ListOfFoundProducts}, {nameof(ValidationErrors)}={ValidationErrors}, {nameof(DBErrors)}={DBErrors}}}";
        }
    }
}

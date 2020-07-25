using ShoppingList.DataModel.Response.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel.Request.Cart
{
    public class AddProductToCartRequest
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AddProductToCartRequest request &&
                   CartId == request.CartId &&
                   ProductId == request.ProductId;
        }

        public override int GetHashCode()
        {
            int hashCode = 1705679091;
            hashCode = hashCode * -1521134295 + CartId.GetHashCode();
            hashCode = hashCode * -1521134295 + ProductId.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{{nameof(CartId)}={CartId.ToString()}, {nameof(ProductId)}={ProductId.ToString()}}}";
        }
    }
}

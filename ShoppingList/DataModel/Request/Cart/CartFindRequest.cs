using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel.Request.Cart
{
    public class CartFindRequest
    {
        public long CartId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CartFindRequest request &&
                   CartId == request.CartId;
        }

        public override int GetHashCode()
        {
            return -1568810734 + CartId.GetHashCode();
        }

        public override string ToString()
        {
            return $"{{{nameof(CartId)}={CartId.ToString()}}}";
        }
    }
}

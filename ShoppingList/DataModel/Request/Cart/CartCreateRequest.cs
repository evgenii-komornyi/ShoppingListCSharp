using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel.Request.Cart
{
    public class CartCreateRequest : CartBasicRequest
    {
        public long CartId { get; set; }
    }
}

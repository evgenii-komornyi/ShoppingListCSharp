using ShoppingList.DataModel.Response.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel
{
    public class CartClearResponse : CartBasicResponse
    {
        public bool HasClear { get; set; }
    }
}

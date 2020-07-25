﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel.Request.Cart
{
    public class CartClearRequest : CartBasicRequest
    {
        public long CartId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CartClearRequest request &&
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

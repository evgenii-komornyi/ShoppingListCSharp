﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel.Request.Cart
{
    public class RemoveProductFromCartRequest
    {
        public long CartId { get; set; }
        public long ProductId { get; set; }
    }
}

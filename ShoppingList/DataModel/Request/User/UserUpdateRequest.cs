﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel.Request.User
{
    public class UserUpdateRequest : UserBasicRequest
    {
        public long Id { get; set; }
    }
}
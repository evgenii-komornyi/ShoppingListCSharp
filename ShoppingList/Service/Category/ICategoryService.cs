﻿using ShoppingList.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}

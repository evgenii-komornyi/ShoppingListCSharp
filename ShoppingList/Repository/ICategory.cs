using ShoppingList.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Repository
{
    public interface ICategory
    {
        List<Category> ReadAll();
    }
}

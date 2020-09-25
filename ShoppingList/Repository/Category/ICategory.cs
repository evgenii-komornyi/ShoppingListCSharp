using ShoppingList.DataModel;
using System.Collections.Generic;

namespace ShoppingList.Repository
{
    public interface ICategory
    {
        List<Category> ReadAll();
    }
}

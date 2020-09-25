using ShoppingList.DataModel;
using System.Collections.Generic;

namespace ShoppingList.Repository.CategoryNS
{
    public interface ICategory
    {
        List<Category> ReadAll();
    }
}

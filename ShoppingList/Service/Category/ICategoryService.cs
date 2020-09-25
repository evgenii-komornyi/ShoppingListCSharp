using ShoppingList.DataModel;
using System.Collections.Generic;

namespace ShoppingList
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}

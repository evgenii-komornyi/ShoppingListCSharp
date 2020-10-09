using ShoppingList.DataModel;
using System.Collections.Generic;

namespace ShoppingList.Service.CategoryNS
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}

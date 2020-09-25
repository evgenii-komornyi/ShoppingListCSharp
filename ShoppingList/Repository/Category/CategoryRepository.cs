using ShoppingList.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingList.Repository
{
    public class CategoryRepository : ICategory
    {
        public List<Category> ReadAll()
        {
            using (var context = new ShoppingListContext())
            {
                return context.Category.OrderBy(c => c.Name).ToList();
            }
        }
    }
}

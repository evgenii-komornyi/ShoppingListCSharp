using ShoppingList.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

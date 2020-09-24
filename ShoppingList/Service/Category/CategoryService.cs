using ShoppingList.DataModel;
using ShoppingList.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    public class CategoryService : ICategoryService
    {
        readonly ICategory _repository;

        public CategoryService(ICategory repository)
        {
            _repository = repository;
        }

        public List<Category> GetAll()
        {
            return _repository.ReadAll();
        }
    }
}

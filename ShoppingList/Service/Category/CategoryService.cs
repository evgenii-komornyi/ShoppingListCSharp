using ShoppingList.DataModel;
using ShoppingList.Repository;
using System.Collections.Generic;

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

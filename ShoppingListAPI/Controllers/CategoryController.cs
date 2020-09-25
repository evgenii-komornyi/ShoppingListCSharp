using DataTransferObjects.CategoryDTO;
using ShoppingList.DataModel;
using ShoppingList.Service.CategoryNS;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ShoppingListAPI.Controllers
{
    [EnableCors(origins: "http://localhost:9000", headers: "*", methods: "*")]
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        [Route("categories")]
        public ListCategoryDTO GetCategories()
        {
            var categoryDTOList = new List<CategoryDTO>();
            var categoryList = _categoryService.GetAll();

            foreach (var category in categoryList)
            {
                categoryDTOList.Add(ConvertToDTO(category));
            }

            return new ListCategoryDTO
            {
                categories = categoryDTOList
            };
        }

        private CategoryDTO ConvertToDTO(Category category)
        {
            return new CategoryDTO
            {
                id = category.Category_Id,
                category = category.Name
            };
        }
    }
}

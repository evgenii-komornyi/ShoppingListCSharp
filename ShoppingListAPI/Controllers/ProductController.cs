using DataTransferObjects.CategoryDTO;
using DataTransferObjects.ProductDTO;
using ShoppingList;
using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Product;
using ShoppingList.Service.Product;
using ShoppingList.Validation.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ShoppingListAPI.Controllers
{
    [EnableCors(origins: "http://localhost:9000", headers: "*", methods: "*")]
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("products")]
        public ListProductDTO GetProducts()
        {
            var productDTOList = new List<ProductDTO>();
            var productList = _productService.FindAll().ListOfFoundProducts;

            foreach (var product in productList)
            {
                productDTOList.Add(СonvertProductToDTO(product));
            }

            return new ListProductDTO
            {
                products = productDTOList
            };
        }

       [HttpGet]
       [Route("{id}")]
       public FindProductDTO GetProductById(long id)
        {
            return new FindProductDTO
            {
                product = СonvertProductToDTO(_productService.FindById(new ProductFindRequest
                {
                    ProductId = id
                }).FoundProduct)
            };
        }

        private ProductDTO СonvertProductToDTO(Product product)
        {
            var errors = new List<string>();

            if (product == null)
            {
                errors.Add("Product not Found");
                return new ProductDTO
                {
                    validationErrors = errors
                };
            }
            else
            {
                return new ProductDTO
                {
                    id = product.Id,
                    name = product.Name,
                    category = product.CategoryName,
                    category_id = product.Category_Id,
                    regPrice = product.Price,
                    discount = product.Discount,
                    actPrice = product.CalculateActualPrice(),
                    description = product.Description,
                    file_id = product.File_Id,
                    image_path = product.FileName
                };
            }
        }
        
        [HttpPost]
        [Route("create")]
        public CreateProductDTO CreateProduct([FromBody]ProductCreateRequest productCreateRequest)
        {
            var product = _productService.CreateProduct(productCreateRequest);
            var responseJson = new CreateProductDTO();
            
            if (product.HasValidationErrors() || product.HasDBErrors())
            {
                responseJson.validationErrors = _convertErrorsToString(product.ValidationErrors);
                responseJson.dbErrors = product.DBErrors;
                responseJson.status = Status.Failed;
            } else
            {
                responseJson.createResponse = product;
                responseJson.status = Status.Success;
            }
            return responseJson;
        }
        
        [HttpPut]
        [Route("{id}")]
        public UpdateProductDTO UpdateProductById(long id, [FromBody]ProductUpdateRequest productUpdateRequest)
        {
            var foundProduct = _productService.FindById(new ProductFindRequest
            {
                ProductId = id
            }).FoundProduct;

            var responseJson = new UpdateProductDTO();

            if (foundProduct != null)
            {
                productUpdateRequest.Id = id;
                var updateResponse = _productService.UpdateById(productUpdateRequest);

                if (updateResponse.HasValidationErrors() || updateResponse.HasDBErrors())
                {
                    responseJson.validationErrors = _convertErrorsToString(updateResponse.ValidationErrors);
                    responseJson.dbErrors = updateResponse.DBErrors;
                    responseJson.status = Status.Failed;
                } else
                {
                    responseJson.product = СonvertProductToDTO(updateResponse.UpdatedProduct);
                    responseJson.status = Status.Success;
                }
            }
            return responseJson;
        }

        private List<string> _convertErrorsToString(List<ProductValidationErrors> errors)
        {
            List<string> convertedErrors = new List<string>();
            if (errors != null)
            {
                foreach (var error in errors)
                {
                    convertedErrors.Add(error.ToString());
                }

            }
            return convertedErrors;
        }

        [HttpDelete]
        [Route("{id}")]
        public DeleteProductDTO DeleteProductById(long id)
        {
            var responseJson = new DeleteProductDTO();
            if (_productService.Delete(new ProductDeleteRequest { Id = id }).HasDeleted) responseJson.status = Status.Success;
            else responseJson.status = Status.Failed;

            return responseJson;
        }
    }
}

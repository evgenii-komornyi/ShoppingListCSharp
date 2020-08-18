using DataTransferObjects.ProductDTO;
using ShoppingList.DataModel;
using ShoppingList.Service.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ShoppingListAPI.Controllers
{
    [EnableCors(origins: "http://localhost:9000", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        public ListProductDTO Get()
        {
            var productDTOList = new List<ProductDTO>();
            var productList = _productService.FindAll().ListOfFoundProducts;

            foreach (var product in productList)
            {
                productDTOList.Add(СonvertProductToDTO(product));
            }

            var responseJSON = new ListProductDTO
            {
                products = productDTOList
            };

            return responseJSON;
        }

        private ProductDTO СonvertProductToDTO(Product product)
        {
            return new ProductDTO
            {
                id = product.Id,
                name = product.Name,
                category = product.CategoryString,
                regPrice = product.Price,
                discount = product.Discount,
                actPrice = product.CalculateActualPrice(),
                description = product.Description
            };
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}

using DataTransferObjects.CartDTO;
using DataTransferObjects.ProductDTO;
using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Cart;
using ShoppingList.Service;
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
    [RoutePrefix("api/cart")]
    public class CartController : ApiController
    {
        readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        [Route("{id}")]
        public CartDTO GetCartById(long id)
        {
            var responseFromService = _cartService.FindCartById(new CartFindRequest
            {
                CartId = id
            });

            var productsInCart = responseFromService.Cart.ProductsCarts;
                        
            var productsDTOList = new List<ProductInCartDTO>();

            foreach (var product in productsInCart)
            {
                productsDTOList.Add(convertProductInCartToDTO(product.Product));
            }

            return new CartDTO
            {
                id = responseFromService.Cart.Id,
                products = productsDTOList,
                amount = responseFromService.Amount
            };
        }

        private ProductInCartDTO convertProductInCartToDTO(Product product)
        {
            return new ProductInCartDTO
            {
                id = product.Id,
                name = product.Name,
                category = product.Category,
                regPrice = product.Price,
                discount = product.Discount,
                actPrice = product.CalculateActualPrice(),
                description = product.Description
            };
        }

        [HttpPost]
        [Route("addToCart")]
        public AddUpdateCartDTO AddUpdateCart([FromBody]AddUpdateCartRequest addProductToCartRequest)
        {
            var responseJson = new AddUpdateCartDTO();
            var serverAnswer = _cartService.AddToCart(addProductToCartRequest);

            if (addProductToCartRequest.Quantity != 0)
            {
                if (serverAnswer.HasAdded)
                {
                    responseJson.productId = addProductToCartRequest.ProductId;
                    responseJson.cartId = addProductToCartRequest.CartId;
                    responseJson.quantity = addProductToCartRequest.Quantity;
                    responseJson.status = Status.Success;
                }
                else
                {
                    responseJson.validationErrors = serverAnswer.ValidationErrors;
                    responseJson.dbErrors = serverAnswer.DBErrors;
                    responseJson.status = Status.Failed;
                }
            }
            else
            {
                RemoveProductFromCart(new RemoveProductFromCartRequest { CartId = addProductToCartRequest.CartId, ProductId = addProductToCartRequest.ProductId });
            }

            return responseJson;
        }
        
        [HttpDelete]
        [Route("removeProduct")]
        public RemoveProductFromCartDTO RemoveProductFromCart([FromBody]RemoveProductFromCartRequest requestForRemoveFromCart)
        {
            var responseJson = new RemoveProductFromCartDTO();
            var serverAnswer = _cartService.RemoveFromCart(requestForRemoveFromCart);

            if (serverAnswer.HasRemoved)
            {
                responseJson.status = Status.Success;
            } else
            {
                responseJson.dbErrors = serverAnswer.DBErrors;
                responseJson.validationErrors = serverAnswer.ValidationErrors;
                responseJson.status = Status.Failed;
            }

            return responseJson;
        }

        [HttpDelete]
        [Route("clearCart")]
        public ClearCartDTO ClearCart([FromBody]CartClearRequest cartClearRequest)
        {
            var responseJson = new ClearCartDTO();
            var serverAnswer = _cartService.ClearCart(cartClearRequest);
            if (serverAnswer.HasClear)
            {
                responseJson.status = Status.Success;
            } else
            {
                responseJson.dbErrors = serverAnswer.DBErrors;
                responseJson.validationErrors = serverAnswer.ValidationErrors;
                responseJson.status = Status.Failed;
            }

            return responseJson;
        }
    }
}

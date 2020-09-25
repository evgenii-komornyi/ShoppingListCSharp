using ShoppingList.DataModel;
using ShoppingList.Exceptions;
using ShoppingList.Repository;
using ShoppingList.Service;
using ShoppingList.Validation;
using ShoppingList.Validation.Cart;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShoppingList
{
    public class CartService : ICartService
    {
        readonly ICart _cartRepository;
        readonly IProductService _productService;
        readonly CartValidation _cartValidation;

        public CartService(ICart cartRepository, IProductService productService, CartValidation cartValidation)
        {
            _cartRepository = cartRepository;
            _productService = productService;
            _cartValidation = cartValidation;
        }

        public CartCreateResponse CreateCart(CartCreateRequest request)
        {
            var response = new CartCreateResponse();
            var validationErrors = _cartValidation.CartCreateRequestValidation.Validate(request);
            var dbErrors = new List<DatabaseErrors>();

            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors;
            }
            else
            {
                try
                {
                    Cart cart = new Cart
                    {
                        Id = request.CartId,
                        UserId = request.UserId
                    };

                    response.Cart = _cartRepository.Create(cart);
                }
                catch (SqlException)
                {
                    dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                }
                response.DBErrors = dbErrors;
            }
            return response;
        }

        public CartFindResponse FindCartById(CartFindRequest request)
        {
            var response = new CartFindResponse();
            var validationErrors = _cartValidation.CartFindRequestValidation.Validate(request);
            var dbErrors = new List<DatabaseErrors>();

            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors;
            }
            else
            {
                try
                {
                    response.Cart = _cartRepository.ReadById(request);
                    response.Amount = _calculateTotalAmount(response.Cart.ProductsCarts);
                }
                catch (SqlException)
                {
                    dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                }
                response.DBErrors = dbErrors;
            }
            return response;
        }

        private decimal _calculateTotalAmount(ICollection<ProductCart> products)
        {
            decimal amount = 0;
            if (products != null && products.Count != 0)
            {
                foreach (var product in products)
                {
                    amount = Decimal.Multiply(product.Quantity, Decimal.Add(amount, product.Product.CalculateActualPrice()));
                }
            }

            return amount;
        }

        public AddUpdateCartResponse AddToCart(AddUpdateCartRequest request)
        {
            var productFindRequest = new ProductFindRequest
            {
                ProductId = request.ProductId
            };

            var cartFindRequest = new CartFindRequest
            {
                CartId = request.CartId
            };

            var product = _productService.FindById(productFindRequest).FoundProduct;
            var cart = FindCartById(cartFindRequest).Cart;

            var validationErrors = _cartValidation.AddProductToCartValidation.Validate(request);
            var DBErrors = new List<DatabaseErrors>();

            var response = new AddUpdateCartResponse();

            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors;
            }
            else
            {
                try
                {
                    response.HasAdded = _cartRepository.ToCart(product, cart, request.Quantity);
                }
                catch (UniqueKeyViolationException)
                {
                    DBErrors.Add(DatabaseErrors.DB_DUPLICATE_ENTRY);
                }
                response.DBErrors = DBErrors;
            }
            return response;
        }

        public RemoveProductFromCartResponse RemoveFromCart(RemoveProductFromCartRequest request)
        {
            var response = new RemoveProductFromCartResponse();
            var validationErrors = _cartValidation.RemoveFromCartRequestValidation.Validate(request);
            var DBErrors = new List<DatabaseErrors>();

            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors;
            }
            else
            {
                try
                {
                    response.HasRemoved = _cartRepository.RemoveFromCart(_findProductInDB(request.ProductId), _findCartInDB(request.CartId));
                } catch(SqlException)
                {
                    DBErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                }
                response.DBErrors = DBErrors;
            }

            return response;
        }

        private long _findCartInDB(long id)
        {
            var cartFindRequest = new CartFindRequest
            {
                CartId = id
            };

            return FindCartById(cartFindRequest).Cart.Id;
        }

        private long _findProductInDB(long id)
        {
            var productFindRequest = new ProductFindRequest
            {
                ProductId = id
            };
            return _productService.FindById(productFindRequest).FoundProduct.Id;
        }

        public CartClearResponse ClearCart(CartClearRequest request)
        {
            var response = new CartClearResponse();
            var validationErrors = _cartValidation.CartClearRequestValidation.Validate(request);
            var dbErrors = new List<DatabaseErrors>();

            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors;
            }
            else
            {
                try
                {
                    response.HasClear = _cartRepository.Clear(request.CartId);
                }
                catch (SqlException)
                {
                    dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                }
                response.DBErrors = dbErrors;
            }
            return response;
        }
    }
}
    
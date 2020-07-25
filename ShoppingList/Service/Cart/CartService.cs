using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Cart;
using ShoppingList.Repository.Cart;
using ShoppingList.Service.Product;
using ShoppingList.Validation;
using ShoppingList.Validation.Errors;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Service
{
    public class CartService
    {
        private ICart _cartRepository;
        private ProductService _productService;

        public CartService(ICart cartRepository, ProductService productService)
        {
            _cartRepository = cartRepository;
            _productService = productService;
        }
        
        public CartCreateResponse CreateCart(CartCreateRequest request)
        {
            CartCreateResponse response = new CartCreateResponse();
            List<CartValidationErrors> validationErrors = new List<CartValidationErrors>();
            List<DatabaseErrors> dbErrors = new List<DatabaseErrors>();

            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors;
            }
            else
            {
                try
                {
                    Cart cart = new Cart();
                    cart.CartId = request.CartId;
                    cart.UserId = request.UserId;

                    response.Cart = _cartRepository.Create(cart);
                }
                catch (SqlException ex)
                {
                    dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                }
                response.DBErrors = dbErrors;
            }
            return response;
        }

        public CartFindResponse FindCartById(CartFindRequest request)
        {
            CartFindResponse response = new CartFindResponse();
            List<CartValidationErrors> validationErrors = new List<CartValidationErrors>();
            List<DatabaseErrors> dbErrors = new List<DatabaseErrors>();

            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors;
            }
            else
            {
                try
                {
                    response.Cart = _cartRepository.ReadById(request);
                    //response.Amount = _calculateTotalAmount(response.Cart.Products);
                }
                catch (SqlException ex)
                {
                    dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                }
                response.DBErrors = dbErrors;
            }
            return response;
        }

        private decimal _calculateTotalAmount(ICollection<DataModel.Product> products)
        {
            decimal amount = 0;
            if (products != null && products.Count != 0)
            {
                foreach (var product in products)
                {
                    amount = Decimal.Add(amount, product.CalculateActualPrice());
                }
            }

            return amount;
        }

        public AddProductToCartResponse AddToCart(AddProductToCartRequest request)
        {
            var response = new AddProductToCartResponse();
            var validationErrors = new List<CartValidationErrors>();
            var DBErrors = new List<DatabaseErrors>();

            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors;
            }
            else
            {
                try
                {

                }
                catch (SqlException)
                {

                    DBErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                }
                response.DBErrors = DBErrors;
            }
            return response;
        }
    }
}

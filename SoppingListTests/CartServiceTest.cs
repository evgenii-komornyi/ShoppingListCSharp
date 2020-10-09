using Moq;
using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.CartNS;
using ShoppingList.DataModel.Request.ProductNS;
using ShoppingList.DataModel.Response.ProductNS;
using ShoppingList.Repository.CartNS;
using ShoppingList.Service.CartNS;
using ShoppingList.Service.ProductNS;
using ShoppingList.Validation.CartNS;
using Xunit;
using Assert = Xunit.Assert;

namespace ShoppingListTests
{
    public class CartServiceTest
    {
        private CartService _victim;
        private readonly IProductService _productService;
        private CartValidation _cartValidation;
        private AddProductToCartValidation _addProductToCartValidation = new AddProductToCartValidation();
        private CartCreateRequestValidation _cartCreateRequestValidation = new CartCreateRequestValidation();
        private CartFindRequestValidation _cartFindRequestValidation = new CartFindRequestValidation();
        private CartRemoveRequestValidation _cartRemoveRequestValidation = new CartRemoveRequestValidation();
        private RemoveFromCartRequestValidation _removeFromCartRequestValidation = new RemoveFromCartRequestValidation();
        private CartClearRequestValidation _cartClearRequestValidation = new CartClearRequestValidation();

        [Fact]
        public void ShouldCreateCart()
        {
            var mockDB = new Mock<ICart>();
            mockDB.Setup(c => c.Create(GetCart()))
                .Returns(GetCart());

            _cartValidation = new CartValidation(_addProductToCartValidation, _cartCreateRequestValidation, _cartFindRequestValidation, _cartRemoveRequestValidation, _removeFromCartRequestValidation, _cartClearRequestValidation);

            _victim = new CartService(mockDB.Object, _productService, _cartValidation);

            var actual = _victim.CreateCart(Request()).Cart;

            Assert.Equal(GetCart(), actual);
        }

        [Fact]
        public void ShouldFindCartById()
        {
            var mockDB = new Mock<ICart>();
            mockDB.Setup(c => c.ReadById(GetCartById()))
                .Returns(GetCart());

            _cartValidation = new CartValidation(_addProductToCartValidation, _cartCreateRequestValidation, _cartFindRequestValidation, _cartRemoveRequestValidation, _removeFromCartRequestValidation, _cartClearRequestValidation);

            _victim = new CartService(mockDB.Object, _productService, _cartValidation);

            var actual = _victim.FindCartById(GetCartById()).Cart;
            
            Assert.Equal(GetCartById().CartId, actual.Id);
        }

        private Cart GetCart()
        {
            Cart cart = new Cart
            {
                Id = 1,
                UserId = 1
            };
            return cart;
        }

        private CartCreateRequest Request()
        {
            CartCreateRequest request = new CartCreateRequest
            {
                CartId = 1,
                UserId = 1
            };
            return request;
        }

        private CartFindRequest GetCartById()
        {
            return new CartFindRequest
            {
                CartId = 1
            };
        }

        [Fact]
        public void ShouldAddProductToCart()
        { 
            var mockDB = new Mock<ICart>();
            mockDB.Setup(c => c.ToCart(GetProduct(), GetCart(), 1))
                .Returns(true);
            
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(p => p.FindById(new ProductFindRequest
            {
                ProductId = 2
            })).Returns(new ProductFindResponse
            {
                FoundProduct = GetProduct()
            });

            mockDB.Setup(c => c.ReadById(GetCartById()))
                .Returns(GetCart());

            _cartValidation = new CartValidation(_addProductToCartValidation, _cartCreateRequestValidation, _cartFindRequestValidation, _cartRemoveRequestValidation, _removeFromCartRequestValidation, _cartClearRequestValidation);

            _victim = new CartService(mockDB.Object, mockProductService.Object, _cartValidation);
                        
            var actual = _victim.AddToCart(AddItemToCart()).HasAdded;
            
            Assert.True(actual);
        }

        private AddUpdateCartRequest AddItemToCart()
        {
            return new AddUpdateCartRequest
            {
                ProductId = 2,
                CartId = 1,
                Quantity = 1
            };
        }

        [Fact]
        public void ShouldRemoveProductFromCart()
        {
            var mockDB = new Mock<ICart>();
            mockDB.Setup(c => c.RemoveFromCart(GetProduct().Id, GetCart().Id))
                .Returns(true);

            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(p => p.FindById(new ProductFindRequest
            {
                ProductId = 2
            })).Returns(new ProductFindResponse
            {
                FoundProduct = GetProduct()
            });

            mockDB.Setup(c => c.ReadById(GetCartById()))
                .Returns(GetCart());

            _cartValidation = new CartValidation(_addProductToCartValidation, _cartCreateRequestValidation, _cartFindRequestValidation, _cartRemoveRequestValidation, _removeFromCartRequestValidation, _cartClearRequestValidation);

            _victim = new CartService(mockDB.Object, mockProductService.Object, _cartValidation);

            var actual = _victim.RemoveFromCart(RemoveRequest()).HasRemoved;

            Assert.True(actual);
        }

        private Product GetProduct()
        {
            return new Product
            {
                Id = 2,
                Name = "Beef",
                Category_Id = 6,
                Price = 50,
                Discount = 50,
                Description = "Fresh meat from Cow."
            };
        }

        private RemoveProductFromCartRequest RemoveRequest()
        {
            return new RemoveProductFromCartRequest
            {
                CartId = 1,
                ProductId = 2
            };
        }

        [Fact]
        public void ShouldClearCart()
        {
            var mockDB = new Mock<ICart>();
            mockDB.Setup(c => c.Clear(GetCart().Id))
                .Returns(true);
            
            var mockProductService = new Mock<IProductService>();

            _cartValidation = new CartValidation(_addProductToCartValidation, _cartCreateRequestValidation, _cartFindRequestValidation, _cartRemoveRequestValidation, _removeFromCartRequestValidation, _cartClearRequestValidation);

            _victim = new CartService(mockDB.Object, mockProductService.Object, _cartValidation);

            var actual = _victim.ClearCart(ClearCartRequest()).HasClear;

            Assert.True(actual);
        }

        private CartClearRequest ClearCartRequest()
        {
            return new CartClearRequest
            {
                CartId = 1
            };
        }
    }
}

using Moq;
using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Cart;
using ShoppingList.Repository.Cart;
using ShoppingList.Service.CartService;
using Xunit;
using Assert = Xunit.Assert;

namespace ShoppingListTests
{
    public class CartServiceTest
    {
        private CartService _victim;

        [Fact]
        public void ShouldCreateCart()
        {
            var mockDB = new Mock<ICart>();
            mockDB.Setup(x => x.Create(getCart()))
                .Returns(getCart());

            _victim = new CartService(mockDB.Object);

            var actual = _victim.CreateCart(request()).Cart;

            Assert.Equal(getCart(), actual);
        }

        [Fact]
        public void ShouldFindCartById()
        {
            var mockDB = new Mock<ICart>();
            mockDB.Setup(x => x.ReadById(getCartById()))
                .Returns(getCart());

            _victim = new CartService(mockDB.Object);

            var actual = _victim.FindCartById(getCartById()).Cart;

            Assert.Equal(getCartById().CartId, actual.CartId);
        }

        private Cart getCart()
        {
            Cart cart = new Cart
            {
                CartId = 1,
                UserId = 1
            };
            return cart;
        }

        private CartCreateRequest request()
        {
            CartCreateRequest request = new CartCreateRequest
            {
                CartId = 1,
                UserId = 1
            };
            return request;
        }

        private CartFindRequest getCartById()
        {
            CartFindRequest request = new CartFindRequest();
            request.CartId = 1;

            return request;
        }

        [Fact]
        public void ShouldAddProductToCart()
        {
            var mockDB = new Mock<ICart>();
            mockDB.Setup(x => x.ToCart(addItemToCart()))
                .Returns(true);

            _victim = new CartService(mockDB.Object);

            var actual = _victim.AddToCart(addProductToCartRequest());
            var productList = actual.Cart;

            Assert.Equal(1, productList.Count);
        }
    }
}

using Moq;
using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Product;
using ShoppingList.Repository.Product;
using ShoppingList.Service.Product;
using ShoppingList.Validation.Product;
using System.Collections.Generic;
using Xunit;
using Assert = Xunit.Assert;

namespace ShoppingListTests
{
    public class ProductServiceTests
    {
        private ProductService _victim;
        
        private CreateRequestValidation _createRequestValidation;
        private FindRequestValidation _findRequestValidation;
        private UpdateRequestValidation _updateRequestValidation;
        private DeleteRequestValidation _deleteRequestValidation;

        private ProductValidation _validation; 

        [Fact]
        public void ShouldReturnCreatedProduct()
        {
            _createRequestValidation = new CreateRequestValidation();
            _deleteRequestValidation = new DeleteRequestValidation();
            _findRequestValidation = new FindRequestValidation();
            _updateRequestValidation = new UpdateRequestValidation();

            _validation = new ProductValidation(_createRequestValidation, _findRequestValidation, _updateRequestValidation, _deleteRequestValidation);

            var mockDB = new Mock<IProduct>();
            mockDB.Setup(x => x.Create(getProduct()))
                .Returns(getProduct());
            
            _victim = new ProductService(mockDB.Object, _validation);

            var actual = _victim.AddProduct(request());
            var expected = getProduct();

            Assert.Equal(expected, actual.Product);
        }

        private Product getProduct()
        {
            Product product = new Product("Milk", Category.Milk, 50);
            product.Discount = 50;
            product.Description = "Good milk from latvia.";

            return product;
        }

        private ProductCreateRequest request()
        {
            ProductCreateRequest request = new ProductCreateRequest();
            request.Name = "Milk";
            request.Category = Category.Milk;
            request.Price = 50;
            request.Discount = 50;
            request.Description = "Good milk from latvia.";
            
            return request;
        }

        [Fact]
        public void ShouldGetAllProducts()
        {
            _createRequestValidation = new CreateRequestValidation();
            _deleteRequestValidation = new DeleteRequestValidation();
            _findRequestValidation = new FindRequestValidation();
            _updateRequestValidation = new UpdateRequestValidation();

            _validation = new ProductValidation(_createRequestValidation, _findRequestValidation, _updateRequestValidation, _deleteRequestValidation);

            var mock = new Mock<IProduct>();

            mock.Setup(x => x.ReadAll())
                .Returns(listProducts);

            _victim = new ProductService(mock.Object, _validation);
            List<Product> actual = _victim.FindAll().ListOfFoundProducts;

            int expected = 3;
            Assert.Equal(expected, actual.Count);
        }

        private List<Product> listProducts()
        {
            var products = new List<Product>()
            {
                new Product {
                    Name = "Milk",
                    Category = Category.Milk,
                    Price = 50,
                    Discount = 20,
                    Description = "Milk from latvia"
                },
                new Product {
                    Name = "Beef",
                    Category = Category.Meat,
                    Price = 100,
                    Discount = 50,
                    Description = "Beef from latvia"
                },
                new Product {
                    Name = "Tess",
                    Category = Category.Tea,
                    Price = 25,
                    Discount = 0,
                    Description = "Tea from latvia"
                }
            };
            return products;
        }

        [Fact]
        public void ShouldGetProductById()
        {
            _createRequestValidation = new CreateRequestValidation();
            _deleteRequestValidation = new DeleteRequestValidation();
            _findRequestValidation = new FindRequestValidation();
            _updateRequestValidation = new UpdateRequestValidation();

            _validation = new ProductValidation(_createRequestValidation, _findRequestValidation, _updateRequestValidation, _deleteRequestValidation);

            ProductFindRequest request = new ProductFindRequest();
            request.Id = 1;

            var mock = new Mock<IProduct>();

            mock.Setup(x => x.ReadSingle(request))
                .Returns(new Product
                {
                    ProductId = 1,
                    Name = "Milk",
                    Category = Category.Milk,
                    Price = 50,
                    Discount = 20,
                    Description = "Milk from latvia"
                });

            _victim = new ProductService(mock.Object, _validation);
            Product actual = _victim.FindById(request).FoundProduct;

            string expected = "Milk";
            Assert.Equal(expected, actual.Name);
        }

        [Fact]
        public void ShouldUpdateById()
        {
            _createRequestValidation = new CreateRequestValidation();
            _deleteRequestValidation = new DeleteRequestValidation();
            _findRequestValidation = new FindRequestValidation();
            _updateRequestValidation = new UpdateRequestValidation();

            _validation = new ProductValidation(_createRequestValidation, _findRequestValidation, _updateRequestValidation, _deleteRequestValidation);

            ProductUpdateRequest request = new ProductUpdateRequest();
            request.Id = 2;
            request.Name = "Pork";
            request.Category = Category.Meat;
            request.Price = 150;
            request.Discount = 50;
            request.Description = "Pork from Nigeria.";

            var mock = new Mock<IProduct>();

            mock.Setup(x => x.Update(request))
                .Returns(new Product
                {
                    ProductId = 2,
                    Name = "Pork",
                    Category = Category.Meat,
                    Price = 150,
                    Discount = 50,
                    Description = "Pork from Nigeria."
                });

            _victim = new ProductService(mock.Object, _validation);
            Product actual = _victim.UpdateById(request).UpdatedProduct;

            string expectedName = "Pork";
            decimal expectedPrice = 150;
            decimal expectedDiscount = 50;

            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expectedPrice, actual.Price);
            Assert.Equal(expectedDiscount, actual.Discount);
        }

        [Fact]
        public void ShouldDeleteById()
        {
            _createRequestValidation = new CreateRequestValidation();
            _deleteRequestValidation = new DeleteRequestValidation();
            _findRequestValidation = new FindRequestValidation();
            _updateRequestValidation = new UpdateRequestValidation();

            _validation = new ProductValidation(_createRequestValidation, _findRequestValidation, _updateRequestValidation, _deleteRequestValidation);

            ProductDeleteRequest request = new ProductDeleteRequest();
            request.Id = 2;

            var mock = new Mock<IProduct>();

            mock.Setup(x => x.Delete(request))
                .Returns(true);

            _victim = new ProductService(mock.Object, _validation);

            Assert.True(_victim.Delete(request).HasDeleted);
        }

        private List<Product> listProductis()
        {
            var products = new List<Product>()
            {
                new Product {
                    ProductId = 1,
                    Name = "Milk",
                    Category = Category.Milk,
                    Price = 50,
                    Discount = 20,
                    Description = "Milk from latvia"
                },
                new Product {
                    ProductId = 2,
                    Name = "Beef",
                    Category = Category.Meat,
                    Price = 100,
                    Discount = 50,
                    Description = "Beef from latvia"
                },
                new Product {
                    ProductId = 3,
                    Name = "Tess",
                    Category = Category.Tea,
                    Price = 25,
                    Discount = 0,
                    Description = "Tea from latvia"
                }
            };
            return products;
        }
    }
}

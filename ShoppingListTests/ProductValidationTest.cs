using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Product;
using ShoppingList.Validation.Errors;
using ShoppingList.Validation.Product;
using System.Collections.Generic;
using Xunit;

namespace ShoppingListTests
{
    public class ProductValidationTest
    {
        [Theory]
        [InlineData("", Category.Milk, 50, 20, "Milk from cows.", ProductValidationErrors.EMPTY_NAME)]
        [InlineData("hj", Category.Milk, 50, 20, "Milk from cows.", ProductValidationErrors.NAME_LENGTH_VIOLATION)]
        [InlineData("Milk", null, 50, 20, "Milk from cows.", ProductValidationErrors.EMPTY_CATEGORY)]
        [InlineData("Milk", Category.Milk, 20, 20, "Milk from cows.", ProductValidationErrors.DISCOUNT_APPLICATION_LIMIT_VIOLATION)]
        public void ShouldReturnErrorCodes(string name, Category category, decimal price, decimal discount, string description, ProductValidationErrors expectedError)
        {
            CreateRequestValidation createRequestValidation = new CreateRequestValidation();
            FindRequestValidation findRequestValidation = new FindRequestValidation();
            UpdateRequestValidation updateRequestValidation = new UpdateRequestValidation();
            DeleteRequestValidation deleteRequestValidation = new DeleteRequestValidation();

            ProductValidation validation = new ProductValidation(createRequestValidation, findRequestValidation,
                                                                updateRequestValidation, deleteRequestValidation);

            ProductCreateRequest request = new ProductCreateRequest
            {
                Name = name,
                Category = category,
                Price = price,
                Discount = discount,
                Description = description
            };

            var listErrors = validation.CreateRequestValidation.ValidateCreateRequest(request);

            foreach (var error in listErrors)
            {
                Assert.Equal(expectedError, error);
            }
        }
    }
}

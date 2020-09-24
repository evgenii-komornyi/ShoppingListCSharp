using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Product;
using ShoppingList.Validation.Errors;
using ShoppingList.Validation.Product;
using System;
using System.Collections.Generic;
using Xunit;

namespace ShoppingListTests
{
    public class ProductValidationTest
    {
        [Theory]
        [InlineData("", 1, 50, 20, "Milk from cows.", 2, ProductValidationErrors.Empty_name)]
        [InlineData("hj", 1, 50, 20, "Milk from cows.", 2, ProductValidationErrors.Name_length_violation)]
        [InlineData("Milk", null, 50, 20, "Milk from cows.", 2, ProductValidationErrors.Empty_category)]
        [InlineData("Milk", 1, 20, 20, "Milk from cows.", 2, ProductValidationErrors.Discount_application_limit_violation)]
        public void ShouldReturnErrorCodes(string name, long category_id, decimal price, decimal discount, string description, long file_id, ProductValidationErrors expectedError)
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
                Category_Id = category_id,
                Price = price,
                Discount = discount,
                Description = description,
                File_Id = file_id
            };

            var listErrors = validation.CreateRequestValidation.Validate(request);

            foreach (var error in listErrors)
            {
                Assert.Equal(expectedError, error);
            }
        }
    }
}

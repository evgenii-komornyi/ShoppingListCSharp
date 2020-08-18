using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Product;
using ShoppingList.Validation.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Validation.Product
{
    public class CreateRequestValidation : Validatable<ProductCreateRequest, ProductValidationErrors>
    {
        public List<ProductValidationErrors> Validate(ProductCreateRequest createFieldRequest)
        {
            List<ProductValidationErrors> allErrors = new List<ProductValidationErrors>();

            allErrors.AddRange(ValidateNameField(createFieldRequest.Name));
            allErrors.AddRange(ValidatePriceField(createFieldRequest.Price));
            allErrors.AddRange(ValidateCategoryField(createFieldRequest.Category));
            allErrors.AddRange(ValidateRangeOfDiscount(createFieldRequest.Discount));
            if (createFieldRequest.Description != null && createFieldRequest.Description.Length != 0)
            {
                allErrors.AddRange(ValidateDescriptionField(createFieldRequest.Description));
            }

            allErrors.AddRange(ValidateDiscountPossibility(createFieldRequest.Price, createFieldRequest.Discount));

            return allErrors;
        }

        private List<ProductValidationErrors> ValidateNameField(String name)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();
            string trimmedName = name.Trim();
            if (trimmedName == null || trimmedName.Length == 0)
            {
                errorsList.Add(ProductValidationErrors.EMPTY_NAME);
            }
            else if (trimmedName.Length < 3 || trimmedName.Length > 32)
            {
                errorsList.Add(ProductValidationErrors.NAME_LENGTH_VIOLATION);
            }
            return errorsList;
        }

        private List<ProductValidationErrors> ValidatePriceField(decimal price)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();

            if (price == null)
            {
                errorsList.Add(ProductValidationErrors.EMPTY_PRICE);
            }
            else
            {
                errorsList.AddRange(NegativeNumberCheck(price));
            }
            return errorsList;
        }

        private List<ProductValidationErrors> NegativeNumberCheck(decimal price)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();

            if (price.CompareTo(Decimal.Zero) <= 0)
            {
                errorsList.Add(ProductValidationErrors.NEGATIVE_OR_ZERO_PRICE);
            }
            return errorsList;
        }

        private List<ProductValidationErrors> ValidateDiscountPossibility(decimal price, decimal discount)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();

            if (price != null && discount != null)
            {
                if (price.CompareTo(20) < 0
                        && discount.CompareTo(Decimal.Zero) != 0)
                {
                    errorsList.Add(ProductValidationErrors.DISCOUNT_APPLICATION_LIMIT_VIOLATION);
                }
            }
            return errorsList;
        }

        private List<ProductValidationErrors> ValidateCategoryField(Category category)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();

            if (category == null)
            {
                errorsList.Add(ProductValidationErrors.EMPTY_CATEGORY);
            }
            return errorsList;
        }

        private List<ProductValidationErrors> ValidateRangeOfDiscount(decimal discount)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();

            if (discount != null)
            {
                if (discount.CompareTo(Decimal.Zero) < 0
                        || discount.CompareTo(100) > 0)
                {
                    errorsList.Add(ProductValidationErrors.INVALID_DISCOUNT_RANGE);
                }
            }
            return errorsList;
        }

        private List<ProductValidationErrors> ValidateDescriptionField(String description)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();

            if (description != null)
            {
                if (description.Length < 8 || description.Length > 60)
                {
                    errorsList.Add(ProductValidationErrors.DESCIPTION_LENGTH_VIOLATION);
                }
            }
            return errorsList;
        }
    }
}

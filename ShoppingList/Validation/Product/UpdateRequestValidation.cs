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
    public class UpdateRequestValidation
    {
        public List<ProductValidationErrors> ValidateUpdateRequest(ProductUpdateRequest updateFieldRequest)
        {
            List<ProductValidationErrors> allErrors = new List<ProductValidationErrors>();

            allErrors.AddRange(ValidateIDField(updateFieldRequest));
            allErrors.AddRange(ValidateNameField(updateFieldRequest.Name));
            allErrors.AddRange(ValidatePriceField(updateFieldRequest.Price));
            allErrors.AddRange(ValidateCategoryField(updateFieldRequest.Category));
            allErrors.AddRange(ValidateRangeOfDiscount(updateFieldRequest.Discount));
            if (updateFieldRequest.Description.Length != 0)
            {
                allErrors.AddRange(ValidateDescriptionField(updateFieldRequest.Description));
            }

            allErrors.AddRange(ValidateDiscountPossibility(updateFieldRequest.Price, updateFieldRequest.Discount));
            allErrors.AddRange(ValidateSearchCriteria(updateFieldRequest));

            return allErrors;
        }

        private List<ProductValidationErrors> ValidateIDField(ProductUpdateRequest updateRequest)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();

            if (updateRequest.Id == null)
            {
                errorsList.Add(ProductValidationErrors.NO_UPDATE_CRITERIA);
            }
            return errorsList;
        }

        private List<ProductValidationErrors> ValidateNameField(String name)
        {
            List<ProductValidationErrors> errorsList = new List<ProductValidationErrors>();
            if (name == null)
            {
                errorsList.Add(ProductValidationErrors.EMPTY_NAME);
            }
            else if (name.Length < 3 || name.Length > 32)
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

        private List<ProductValidationErrors> ValidateSearchCriteria(ProductUpdateRequest updateRequest)
        {
            List<ProductValidationErrors> allErrors = new List<ProductValidationErrors>();

            if (updateRequest.Id == null)
            {
                allErrors.Add(ProductValidationErrors.NO_UPDATE_CRITERIA);
            }

            return allErrors;
        }
    }
}

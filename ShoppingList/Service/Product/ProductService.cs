using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Product;
using ShoppingList.DataModel.Response.Product;
using ShoppingList.Repository.Product;
using ShoppingList.Validation;
using ShoppingList.Validation.Errors;
using ShoppingList.Validation.Product;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Service.Product
{
    public class ProductService
    {
        private IProduct _productRepository;
        private ProductValidation _validation;

        public ProductService(IProduct repository, ProductValidation validation)
        {
            this._productRepository = repository;
            this._validation = validation;
        }

        public ProductCreateResponse AddProduct(ProductCreateRequest request)
        {
            ProductCreateResponse response = new ProductCreateResponse();
            List<ProductValidationErrors> validationErrors = _validation.CreateRequestValidation.ValidateCreateRequest(request);
            List<DatabaseErrors> dbErrors = new List<DatabaseErrors>();

            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors;
            }
            else
            {
                try
                {
                    DataModel.Product product = new DataModel.Product(request.Name, request.Category, request.Price);

                    if (request.Discount == null)
                    {
                        product.Discount = Decimal.Zero;
                    }
                    else
                    {
                        product.Discount = request.Discount;
                    }

                    product.Description = request.Description;
                    response.Product = _productRepository.Create(product);
                } catch(SqlException ex)
                {
                    dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                }
                response.DBErrors = dbErrors;
            }

            return response;
        }

        public ProductFindResponse FindById(ProductFindRequest request)
        {
            ProductFindResponse response = new ProductFindResponse();
            List<ProductValidationErrors> validationErrors = _validation.FindRequestValidation.ValidateFindRequest(request);
            List<DatabaseErrors> dbErrors = new List<DatabaseErrors>();
         
            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors;

            }
            else
            {
                try
                {
                    response.FoundProduct = _productRepository.ReadSingle(request);
                }
                catch (SqlException ex)
                {
                    dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                }
                response.DBErrors = dbErrors;
            }

            return response;
        }

        public ProductFindResponse FindAll()
        {
            ProductFindResponse response = new ProductFindResponse();
            List<DatabaseErrors> dbErrors = new List<DatabaseErrors>();

            try
            {
                response.ListOfFoundProducts = _productRepository.ReadAll();
            }
            catch (SqlException ex)
            {
                dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
            }
            response.DBErrors = dbErrors;
            return response;
        }

        public ProductUpdateResponse UpdateById(ProductUpdateRequest request)
        {
            ProductUpdateResponse response = new ProductUpdateResponse();
            List<ProductValidationErrors> validationErrors = _validation.UpdateRequestValidation.ValidateUpdateRequest(request);
            List<DatabaseErrors> dbErrors = new List<DatabaseErrors>();

            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors;
            }
            else
            {
                try
                {
                    response.UpdatedProduct = _productRepository.Update(request);
                }
                catch (SqlException ex)
                {
                    dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                }
                response.DBErrors = dbErrors;
            }

            return response;
        }

        public ProductDeleteResponse Delete(ProductDeleteRequest request)
        {
            ProductDeleteResponse response = new ProductDeleteResponse();
            List<ProductValidationErrors> validationErrors = _validation.DeleteRequestValidation.ValidateDeleteRequest(request);
            List<DatabaseErrors> dbErrors = new List<DatabaseErrors>();

            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors; 
            }
            else
            {
                try
                {
                    response.HasDeleted = _productRepository.Delete(request);
                }
                catch (SqlException ex)
                {
                    dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                }
                response.DBErrors = dbErrors;
            }
            return response;
        }

        public void Save()
        {
            _productRepository.SaveChanges();
        }
    }
}

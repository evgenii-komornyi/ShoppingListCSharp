using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.ProductNS;
using ShoppingList.DataModel.Response.ProductNS;
using ShoppingList.Repository.ProductNS;
using ShoppingList.Validation.Errors;
using ShoppingList.Validation.ProductNS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShoppingList.Service.ProductNS
{
    public class ProductService : IProductService
    {
        readonly IProduct _productRepository;
        readonly ProductValidation _validation;

        public ProductService(IProduct repository, ProductValidation validation)
        {
            _productRepository = repository;
            _validation = validation;
        }

        public ProductCreateResponse CreateProduct(ProductCreateRequest request)
        {
            var response = new ProductCreateResponse();
            var validationErrors = _validation.CreateRequestValidation.Validate(request);
            var dbErrors = new List<DatabaseErrors>();

            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors;
            }
            else
            {
                try
                {
                    var product = AddProductToDB(request);

                    if (product == null) throw new NullReferenceException("Product not found");
                    
                    response.Product = product;
                }
                catch (NullReferenceException)
                {
                        dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                    
                }
                response.DBErrors = dbErrors;
            }

            return response;
        }

        private Product AddProductToDB(ProductCreateRequest request)
        {   
            return _productRepository.Create(
                new Product(request.Name, request.Category_Id, request.Price)
                { 
                    Discount = (request.Discount == null) ? Decimal.Zero : request.Discount,
                    Description = request.Description,
                    File_Id = request.File_Id
                }
            );
        }

        public ProductFindResponse FindById(ProductFindRequest request)
        {
            var response = new ProductFindResponse();
            var validationErrors = _validation.FindRequestValidation.Validate(request);
            var dbErrors = new List<DatabaseErrors>();

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
                catch (SqlException)
                {
                    dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                } 
                catch (NullReferenceException)
                {
                    validationErrors.Add(ProductValidationErrors.Product_Not_Found);
                }
                response.DBErrors = dbErrors;
            }

            return response;
        }

        public ProductFindResponse FindAll()
        {
            var response = new ProductFindResponse();
            var dbErrors = new List<DatabaseErrors>();

            try
            {
                response.ListOfFoundProducts = _productRepository.ReadAll();
            }
            catch (SqlException)
            {
                dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
            }
            response.DBErrors = dbErrors;
            return response;
        }

        public ProductUpdateResponse UpdateById(ProductUpdateRequest request)
        {
            var response = new ProductUpdateResponse();
            var validationErrors = _validation.UpdateRequestValidation.Validate(request);
            var dbErrors = new List<DatabaseErrors>();

            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors;
            }
            else
            {
                try
                {
                    if (_productRepository.Update(request) == 1)
                    {
                        var product = new Product
                        {
                            Id = request.Id,
                            Name = request.Name,
                            Category_Id = request.Category_Id,
                            Price = request.Price,
                            Discount = request.Discount,
                            Description = request.Description,
                            File_Id = request.File_Id
                            
                        };
                        response.UpdatedProduct = product;
                    }
                }
                catch (SqlException e)
                {
                    dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                }
                response.DBErrors = dbErrors;
            }

            return response;
        }

        public ProductDeleteResponse Delete(ProductDeleteRequest request)
        {
            var response = new ProductDeleteResponse();
            var validationErrors = _validation.DeleteRequestValidation.Validate(request);
            var dbErrors = new List<DatabaseErrors>();

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
using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Product;
using ShoppingList.Repository.Product;
using ShoppingList.Service.Product;
using ShoppingList.Validation.Errors;
using ShoppingList.Validation.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateRequestValidation createRequestValidation = new CreateRequestValidation();
            FindRequestValidation findRequestValidation = new FindRequestValidation();
            UpdateRequestValidation updateRequestValidation = new UpdateRequestValidation();
            DeleteRequestValidation deleteRequestValidation = new DeleteRequestValidation();

            ProductValidation productValidation = new ProductValidation(createRequestValidation, findRequestValidation,
                                                                        updateRequestValidation, deleteRequestValidation);

            ShoppingListContext context = new ShoppingListContext();

            ProductRepository productRepository = new ProductRepository(context);
            ProductService productService = new ProductService(productRepository, productValidation);

            ProductDeleteRequest request = new ProductDeleteRequest();
            request.Id = 1;
            
            Console.WriteLine(productService.Delete(request));
            productService.Save();
        }
    }
}

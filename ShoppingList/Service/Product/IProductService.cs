using ShoppingList.DataModel;
using ShoppingList.DataModel.Request;
using ShoppingList.DataModel.Request.Product;
using ShoppingList.DataModel.Response;
using ShoppingList.DataModel.Response.Product;

namespace ShoppingList.Service.Product
{
    public interface IProductService
    {
        ProductCreateResponse CreateProduct(ProductCreateRequest request);
        ProductDeleteResponse Delete(ProductDeleteRequest request);
        ProductFindResponse FindAll();
        ProductFindResponse FindById(ProductFindRequest request);
        ProductUpdateResponse UpdateById(ProductUpdateRequest request);
    }
}
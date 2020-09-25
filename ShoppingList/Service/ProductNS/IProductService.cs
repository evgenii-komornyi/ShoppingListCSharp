using ShoppingList.DataModel.Request.ProductNS;
using ShoppingList.DataModel.Response.ProductNS;

namespace ShoppingList.Service.ProductNS
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
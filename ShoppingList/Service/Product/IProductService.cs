using ShoppingList.DataModel;

namespace ShoppingList.Service
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
using ShoppingList.DataModel.Response.ProductNS;

namespace DataTransferObjects.ProductDTO
{
    public class CreateProductDTO : ProductBasicDTO
    {
        public ProductCreateResponse createResponse { get; set; }
    }
}

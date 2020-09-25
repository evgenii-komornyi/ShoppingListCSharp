using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.ProductNS;
using System.Collections.Generic;

namespace ShoppingList.Repository.ProductNS
{
    public interface IProduct
    {
        Product Create(Product product);
        Product ReadSingle(ProductFindRequest request);
        List<Product> ReadAll();
        int Update(ProductUpdateRequest request);
        bool Delete(ProductDeleteRequest request);
    }
}

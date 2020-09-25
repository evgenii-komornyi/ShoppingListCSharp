using ShoppingList.DataModel;
using System.Collections.Generic;

namespace ShoppingList.Repository
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

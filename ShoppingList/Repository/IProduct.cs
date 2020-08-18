using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Repository.Product
{
    public interface IProduct
    {
        DataModel.Product Create(DataModel.Product product);
        DataModel.Product ReadSingle(ProductFindRequest request);
        List<DataModel.Product> ReadAll();
        DataModel.Product Update(ProductUpdateRequest request);
        bool Delete(ProductDeleteRequest request);
        void SaveChanges();
    }
}

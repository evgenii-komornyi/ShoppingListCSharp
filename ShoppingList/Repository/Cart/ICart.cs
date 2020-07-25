using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Repository.Cart
{
    public interface ICart
    {
        DataModel.Cart Create(DataModel.Cart cart);
        DataModel.Cart ReadById(CartFindRequest request);
    }
}

using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Repository
{
    public interface ICart
    {
        Cart Create(Cart cart);
        Cart ReadById(CartFindRequest request);
        bool ToCart(Product product, Cart cart, int quantity);
        bool RemoveFromCart(long ProductId, long CartId);
        bool Clear(long CartId);
    }
}

using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Repository.Cart
{
    public class CartRepository : ICart
    {
        private readonly ShoppingListContext _context;

        public CartRepository(ShoppingListContext context)
        {
            _context = context;
        }

        public DataModel.Cart Create(DataModel.Cart cart)
        {
            _context.Carts.Add(cart);
            return cart;
        }

        public DataModel.Cart ReadById(CartFindRequest request)
        {
            return _context.Carts.FirstOrDefault(c => c.CartId == request.CartId);
        }
    }
}

using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Cart;
using ShoppingList.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Repository
{
    public class CartRepository : ICart
    {
        private readonly ShoppingListContext _context;

        public CartRepository(ShoppingListContext context)
        {
            _context = context;
        }

        public Cart Create(Cart cart)
        {
            using (var _context = new ShoppingListContext())
            {
                _context.Cart.Add(cart);
                DbContextHelper.HandleUniqueKeyViolation(() => _context.SaveChanges());
                return cart;
            }
        }

        public Cart ReadById(CartFindRequest request)
        {
            using (var _context = new ShoppingListContext())
            {
                return _context.Cart.FirstOrDefault(c => c.Id == request.CartId);
            }
        }

        public bool ToCart(Product product, Cart cart)
        {
            using (var _context = new ShoppingListContext())
            {
                _context.ProductCart.Add(new ProductCart() { Cart_CartId = cart.Id, Product_ProductId = product.Id });
                DbContextHelper.HandleUniqueKeyViolation(() => _context.SaveChanges());

                return true;
            }
        }

        public bool RemoveFromCart(long productId, long cartId) 
        {
            using (var _context = new ShoppingListContext())
            {
                var productCart = _context.ProductCart.FirstOrDefault(x => x.Cart_CartId == cartId && x.Product_ProductId == productId);
                if (productCart != null)
                {
                    _context.ProductCart.Remove(productCart);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Clear(long cartId)
        {
            var cart = _context.Cart.FirstOrDefault(x => x.Id == cartId).Products;

            if (_context.Database.ExecuteSqlCommand("delete ProductCart where (Cart_CartId=@CartId)", new SqlParameter("@CartId", SqlDbType.BigInt){ Value = cartId }) == 1) 
            {
                return true;
            }
            return false;
        }
    }
}

using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Product;
using ShoppingList.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly ShoppingListContext _context;

        public ProductRepository(ShoppingListContext context)
        {
            _context = context;
        }

        public Product Create(Product product)
        {
            _context.Database.ExecuteSqlCommand("INSERT INTO Product (Name, Category, Price, Discount, Description) VALUES (@name, @category, @price, @discount, @description)",
                new SqlParameter("name", product.Name),
                new SqlParameter("category", product.CategoryString),
                new SqlParameter("price", product.Price),
                new SqlParameter("discount", product.Discount),
                new SqlParameter("description", product.Description)
            );
            
            return product;
        }

        public List<Product> ReadAll()
        {
            using (var _context = new ShoppingListContext())
            {
                return _context.Product.Select(p => p).ToList();
            }
        }

        public Product ReadSingle(ProductFindRequest request)
        {
            using (var _context = new ShoppingListContext())
            {
                return _context.Product.FirstOrDefault(p => p.Id == request.ProductId);
            }
        }

        public int Update(ProductUpdateRequest request)
        {
            return _context.Database.ExecuteSqlCommand("UPDATE Product SET Name = @name, Category = @category, Price = @price, Discount = @discount, Description = @description WHERE Id = @Id",
                new SqlParameter("Id", request.Id),
                new SqlParameter("name", request.Name),
                new SqlParameter("category", request.CategoryString),
                new SqlParameter("price", request.Price),
                new SqlParameter("discount", request.Discount),
                new SqlParameter("description", request.Description)
            );
        }

        public bool Delete(ProductDeleteRequest request)
        {
            using (var _context = new ShoppingListContext())
            {
                Product product = _context.Product.FirstOrDefault(p => p.Id == request.Id);

                if (product != null)
                {
                    _context.Product.Remove(product);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}

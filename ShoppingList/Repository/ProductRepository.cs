using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Product;
using ShoppingList.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            var insertedId = _context.Database.SqlQuery<long>("INSERT INTO Product (Name, Category_Category_Id, Price, Discount, Description, File_File_Id) output INSERTED.ID VALUES (@name, @category_id, @price, @discount, @description, @file_id)",
                new SqlParameter("name", product.Name),
                new SqlParameter("category_id", product.Category_Id),
                new SqlParameter("price", product.Price),
                new SqlParameter("discount", product.Discount),
                new SqlParameter("description", product.Description),
                new SqlParameter("file_id", product.File_Id)
            ).FirstOrDefault();
            product.Id = insertedId;

            return product;
        }

        public List<Product> ReadAll()
        {
            using (var _context = new ShoppingListContext())
            {
                return _context.Product
                    .Include(c => c.Category)
                    .Include(f => f.FileStorage)
                    .ToList();            
            }
        }

        public Product ReadSingle(ProductFindRequest request)
        {
            using (var _context = new ShoppingListContext())
            {       
                return _context.Product
                    .Include(c => c.Category)
                    .Include(f => f.FileStorage)
                    .FirstOrDefault(p => p.Id == request.ProductId);
            }
        }

        public int Update(ProductUpdateRequest request)
        {
            return _context.Database.ExecuteSqlCommand("UPDATE Product SET Name = @name, Category_Category_Id = @category_id, Price = @price, Discount = @discount, Description = @description, File_File_Id = @file_id WHERE Id = @Id",
                new SqlParameter("Id", request.Id),
                new SqlParameter("name", request.Name),
                new SqlParameter("category_id", request.Category_Id),
                new SqlParameter("price", request.Price),
                new SqlParameter("discount", request.Discount),
                new SqlParameter("description", request.Description),
                new SqlParameter("file_id", request.File_Id)
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

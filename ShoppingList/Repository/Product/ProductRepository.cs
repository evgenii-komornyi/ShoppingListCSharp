using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Repository.Product
{
    public class ProductRepository : IProduct
    {
        private readonly ShoppingListContext _context;

        public ProductRepository(ShoppingListContext context)
        {
            _context = context;
        }

        public DataModel.Product Create(DataModel.Product product)
        {
            _context.Products.Add(product);
            return product;
        }

        public List<DataModel.Product> ReadAll()
        {
            return _context.Products.Select(x => x).ToList();
        }

        public DataModel.Product ReadSingle(ProductFindRequest request)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == request.Id);
        }

        public DataModel.Product Update(ProductUpdateRequest request)
        {
            DataModel.Product product = _context.Products.Find(request.Id);
            product.Name = request.Name;
            product.Category = request.Category;
            product.Price = request.Price;
            product.Discount = request.Discount;
            product.Description = request.Description;

            return product;
        }

        public bool Delete(ProductDeleteRequest request)
        {
            DataModel.Product product = _context.Products.FirstOrDefault(p => p.ProductId == request.Id);

            if (product != null)
            {
                _context.Products.Remove(product);
                return true;
            } else
            {
                return false;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

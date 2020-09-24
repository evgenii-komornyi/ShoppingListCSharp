using ShoppingList.DataModel.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.ProductDTO
{
    public class DeleteProductDTO : ProductBasicDTO
    {
        public Status status { get; set; }
    }
}

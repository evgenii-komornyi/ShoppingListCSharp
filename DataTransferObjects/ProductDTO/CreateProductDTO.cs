using ShoppingList.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.ProductDTO
{
    public class CreateProductDTO : ProductBasicDTO
    {
        public ProductCreateResponse createResponse { get; set; }
    }
}

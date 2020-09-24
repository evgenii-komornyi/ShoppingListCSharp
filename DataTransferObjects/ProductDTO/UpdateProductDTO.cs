using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.ProductDTO
{
    public class UpdateProductDTO : ProductBasicDTO
    {
        public ProductDTO product { get; set; }
    }
}

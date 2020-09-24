using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.ProductDTO
{
    public class ListProductDTO : ProductBasicDTO
    {
        public List<ProductDTO> products { get; set; }
    }
}

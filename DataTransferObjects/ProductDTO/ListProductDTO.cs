using System.Collections.Generic;

namespace DataTransferObjects.ProductDTO
{
    public class ListProductDTO : ProductBasicDTO
    {
        public List<ProductDTO> products { get; set; }
    }
}

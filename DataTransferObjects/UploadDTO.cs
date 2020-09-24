using DataTransferObjects.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class UploadDTO : ProductBasicDTO
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string FileCategory { get; set; }
    }
}

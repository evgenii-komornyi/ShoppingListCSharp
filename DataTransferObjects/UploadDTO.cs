using DataTransferObjects.ProductDTO;

namespace DataTransferObjects
{
    public class UploadDTO : ProductBasicDTO
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string FileCategory { get; set; }
    }
}

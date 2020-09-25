namespace DataTransferObjects.FileStorageDTO
{
    public class FileStorageDTO : FileStorageBasicDTO
    {
        public long Id { get; set; }
        public string File { get; set; }
        public string Category { get; set; }
    }
}

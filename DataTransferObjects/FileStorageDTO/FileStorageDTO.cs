using ShoppingList.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.FileStorageDTO
{
    public class FileStorageDTO : FileStorageBasicDTO
    {
        public long Id { get; set; }
        public string File { get; set; }
        public string Category { get; set; }
    }
}

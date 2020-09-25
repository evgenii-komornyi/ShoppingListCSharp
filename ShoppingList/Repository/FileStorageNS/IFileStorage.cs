using ShoppingList.DataModel;
using System.Collections.Generic;

namespace ShoppingList.Repository.FileStorageNS
{
    public interface IFileStorage
    {
        FileStorage Create(FileStorage fileStorage);
        List<FileStorage> ReadAll();        
    }
}

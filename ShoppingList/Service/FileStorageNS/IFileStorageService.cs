using ShoppingList.DataModel;
using System.Collections.Generic;

namespace ShoppingList.Service.FileStorageNS
{
    public interface IFileStorageService
    {
        FileStorage Create(string fileName, string fileCategory);
        List<FileStorage> GetAll();
    }
}

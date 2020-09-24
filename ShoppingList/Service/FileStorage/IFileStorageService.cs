using ShoppingList.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    public interface IFileStorageService
    {
        FileStorage Create(string fileName, string fileCategory);
        List<FileStorage> GetAll();
    }
}

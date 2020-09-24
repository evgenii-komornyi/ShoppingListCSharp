using ShoppingList.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Repository
{
    public interface IFileStorage
    {
        FileStorage Create(FileStorage fileStorage);
        List<FileStorage> ReadAll();        
    }
}

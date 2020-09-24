using ShoppingList.DataModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Repository
{
    public class FileStorageRepository : IFileStorage
    {
        private readonly ShoppingListContext _context;

        public FileStorageRepository(ShoppingListContext context)
        {
            _context = context;
        }
        public FileStorage Create(FileStorage file)
        {
            var insertedId = _context.Database.SqlQuery<long>("INSERT INTO FileStorage (Name, Category) output INSERTED.FILE_ID VALUES (@name, @category)",
                new SqlParameter("name", file.Name),
                new SqlParameter("category", file.Category)
            ).FirstOrDefault();
            file.File_Id = insertedId;

            return file;
        }

        public List<FileStorage> ReadAll()
        {
            using(var context = new ShoppingListContext())
            {
                return context.FileStorage.ToList();
            } 
        }
    }
}

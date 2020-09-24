﻿using ShoppingList.DataModel;
using ShoppingList.Repository;
using ShoppingList.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    public class FileStorageService : IFileStorageService
    {
        readonly IFileStorage _fileRepository;

        public FileStorageService(IFileStorage fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public FileStorage Create(string fileName, string fileCategory)
        {
            var file = new FileStorage
            {
                Name = fileName,
                Category = fileCategory
            };

            return _fileRepository.Create(file);
        }

        public List<FileStorage> GetAll()
        {
            return _fileRepository.ReadAll();
        }
    }
}

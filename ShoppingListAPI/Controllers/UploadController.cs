using DataTransferObjects.FileStorageDTO;
using ShoppingList;
using ShoppingList.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ShoppingListAPI.Controllers
{
    [EnableCors(origins: "http://localhost:9000", headers: "*", methods: "*")]
    [RoutePrefix("api/upload")]
    public class UploadController : ApiController
    {
        readonly IFileStorageService _fileService;

        public UploadController(IFileStorageService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        [Route("files")]
        public ListFileStorageDTO GetAllFiles()
        {
            var fileStorageDTOList = new List<FileStorageDTO>();
            var fileList = _fileService.GetAll();

            foreach (var file in fileList)
            {
                fileStorageDTOList.Add(ConvertToDTO(file));
            }

            return new ListFileStorageDTO
            {
                files = fileStorageDTOList
            };
        }

        [HttpPost]
        [Route("create")]
        public FileStorageDTO UploadFile([FromUri] string fileName, [FromUri] string fileCategory)
        {
            var responseJson = new FileStorageDTO();

            try
            {
                if ((HttpContext.Current.Request.InputStream == null) ||
                    (HttpContext.Current.Request.InputStream.Length == 0))
                {
                    throw new ArgumentException("Input stream is empty!");
                }

                var config = WebConfigurationManager.AppSettings;
                string rootPath;

                if (fileCategory.Equals("product"))
                {
                    rootPath = HttpContext.Current.Server.MapPath(config.Get("defaultPathToImages") + config.Get("productsPath"));
                }

                rootPath = HttpContext.Current.Server.MapPath(config.Get("defaultPathToImages") + config.Get("productsPath"));

                using (var ms = new MemoryStream())
                {
                    var httpRequest = HttpContext.Current.Request;
                    httpRequest.InputStream.CopyTo(ms);
                    var postedFileBytes = ms.ToArray();

                    File.WriteAllBytes(Path.Combine(rootPath, fileName), postedFileBytes);
                }

                responseJson = ConvertToDTO(_fileService.Create(fileName, fileCategory));      
            }
            catch (Exception ex)
            {
                responseJson.Error = ex.Message;   
            }
            return responseJson;
        }

        private FileStorageDTO ConvertToDTO(FileStorage file)
        {
            return new FileStorageDTO
            {
                Id = file.File_Id,
                File = file.Name,
                Category = file.Category
            };
        }
    }
}

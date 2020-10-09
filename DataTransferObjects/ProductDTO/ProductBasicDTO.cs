using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace DataTransferObjects.ProductDTO
{
    public class ProductBasicDTO
    {
        public Status status { get; set; }
        public List<string> validationErrors { get; set; }
        public List<DatabaseErrors> dbErrors { get; set; }
        public string Exception { get; set; }
    }
}

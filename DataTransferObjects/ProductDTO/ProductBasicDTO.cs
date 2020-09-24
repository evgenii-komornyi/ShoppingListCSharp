using ShoppingList.Validation;
using ShoppingList.Validation.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

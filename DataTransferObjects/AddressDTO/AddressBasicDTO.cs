using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace DataTransferObjects.AddressDTO
{
    public class AddressBasicDTO
    {
        public List<string> validationErrors { get; set; }
        public List<DatabaseErrors> dbErrors { get; set; }
    }
}

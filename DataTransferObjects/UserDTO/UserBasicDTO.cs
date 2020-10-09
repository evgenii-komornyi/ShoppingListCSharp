using ShoppingList.Validation.Errors;
using System.Collections.Generic;

namespace DataTransferObjects.UserDTO
{
    public class UserBasicDTO
    {
        public List<string> validationErrors { get; set; }
        public List<DatabaseErrors> dbErrors { get; set; }
    }
}

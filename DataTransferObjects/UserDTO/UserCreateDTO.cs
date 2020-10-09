using ShoppingList.DataModel.Response.UserNS;

namespace DataTransferObjects.UserDTO
{
    public class UserCreateDTO : UserBasicDTO
    {
        public long UserId { get; set; }
    }
}

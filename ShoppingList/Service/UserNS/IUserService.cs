using ShoppingList.DataModel.Request.UserNS;
using ShoppingList.DataModel.Response.UserNS;

namespace ShoppingList.Service.UserNS
{
    public interface IUserService
    {
        UserCreateResponse CreateUser(UserCreateRequest createRequest);
    }
}

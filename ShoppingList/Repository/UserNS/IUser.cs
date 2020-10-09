using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.UserNS;

namespace ShoppingList.Repository.UserNS
{
    public interface IUser
    {
        User Create(User user);
        User ReadById(UserFindRequest request);
        int Update(UserUpdateRequest request);
        bool Delete(UserDeleteRequest request);
    }
}

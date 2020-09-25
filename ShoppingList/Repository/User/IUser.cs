using ShoppingList.DataModel;

namespace ShoppingList.Repository
{
    public interface IUser
    {
        User Create(User user);
        User ReadById(UserFindRequest request);
        int Update(UserUpdateRequest request);
        bool Delete(UserDeleteRequest request);
    }
}

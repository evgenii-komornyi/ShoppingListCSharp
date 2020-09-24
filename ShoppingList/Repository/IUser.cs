using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

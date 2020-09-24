using ShoppingList.DataModel;
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
        User ReadById(long id);
        User Update(long id, User user);
        bool Delete(long id);
    }
}

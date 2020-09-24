using ShoppingList.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Repository
{
    public class UserRepository : IUser
    {
        private readonly ShoppingListContext _context;

        public UserRepository(ShoppingListContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            long returnedId = 
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public User ReadById(long id)
        {
            throw new NotImplementedException();
        }

        public User Update(long id, User user)
        {
            throw new NotImplementedException();
        }
    }
}

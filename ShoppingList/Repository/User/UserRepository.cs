using ShoppingList.DataModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

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
            long returnedId = _context.Database.SqlQuery<long>(
                    "INSERT INTO User (FName, LName, Birthday, Login, Role, Hash, Salt, Address_Address_Id, CreaationDate) output Inserted.ID VALUES (@fname, @lname, @birthday, @login, @role, @hash, @salt, @def_addr_id, @creation_date)",
                    new SqlParameter("fname", user.FName),
                    new SqlParameter("lname", user.LName),
                    new SqlParameter("birthday", user.Birthday),
                    new SqlParameter("login", user.Login),
                    new SqlParameter("role", user.Role),
                    new SqlParameter("hash", user.Hash),
                    new SqlParameter("salt", user.Salt),
                    new SqlParameter("def_addr_id", user.Address_Id),
                    new SqlParameter("creation_date", user.CreationDate)
                ).FirstOrDefault();
            user.Id = returnedId;

            return user;
        }

        public User ReadById(UserFindRequest request)
        {
            using (var _context = new ShoppingListContext())
            {
                return _context.User
                    .Where(u => u.Id == request.Id)
                    .Include(au => au.Addresses.Select(u => u.User_Id == request.Id))
                    .FirstOrDefault();
            }
        }

        public int Update(UserUpdateRequest request)
        {
            return _context.Database.ExecuteSqlCommand(
                "UPDATE User SET FName = @fname, LName = @lname, Birthday = @birthday, Login = @login, Address_Address_Id = @def_addr_id WHERE Id = @Id",
                new SqlParameter("Id", request.Id),
                new SqlParameter("fname", request.FirstName),
                new SqlParameter("lname", request.LastName),
                new SqlParameter("birthday", request.Birthday),
                new SqlParameter("login", request.Login),
                new SqlParameter("def_addr_id", request.DefaultAddress_Id)
            );
        }

        public bool Delete(UserDeleteRequest request)
        {
            using (var _context = new ShoppingListContext())
            {
                var user = _context.User.FirstOrDefault(u => u.Id == request.Id);

                if (user == null)
                {
                    return false;
                }

                _context.User.Remove(user);
                _context.SaveChanges();

                return true;

            }
        }
    }
}

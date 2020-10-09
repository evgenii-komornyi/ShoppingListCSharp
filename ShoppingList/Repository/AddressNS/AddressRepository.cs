using ShoppingList.DataModel;
using System.Data.SqlClient;
using System.Linq;

namespace ShoppingList.Repository.AddressNS
{
    public class AddressRepository : IAddress
    {
        readonly ShoppingListContext _context;

        public AddressRepository(ShoppingListContext context)
        {
            _context = context;
        }

        public Address Create(Address address)
        {
            var insertedId = _context.Database.SqlQuery<long>("INSERT INTO Address (Country, City, Street, House_Number, Flat_Number, Additional_Info, Phone, User_Id) output INSERTED.ADDRESS_ID VALUES (@country, @city, @street, @house, @flat, @info, @phone, @user_id)",
                new SqlParameter("country", address.Country), 
                new SqlParameter("city", address.City), 
                new SqlParameter("street", address.Street), 
                new SqlParameter("house", address.House_Number), 
                new SqlParameter("flat", address.Flat_Number), 
                new SqlParameter("info", address.Additional_Info), 
                new SqlParameter("phone", address.Phone), 
                new SqlParameter("user_id", address.User_Id) 
                ).FirstOrDefault();
            address.Address_Id = insertedId;

            return address;
        }
    }
}

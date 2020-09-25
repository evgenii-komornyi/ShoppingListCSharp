using ShoppingList.DataModel;
using System;

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
            throw new NotImplementedException();
        }
    }
}

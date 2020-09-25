using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Address;
using ShoppingList.Repository;
using System;

namespace ShoppingList.Service
{
    public class AddressService : IAddressService
    {
        readonly IAddress _repository;

        public AddressService(IAddress repository)
        {
            _repository = repository;
        }

        public AddressCreateResponse CreateAddress(AddressCreateRequest createRequest)
        {
            throw new NotImplementedException();
        }
    }
}

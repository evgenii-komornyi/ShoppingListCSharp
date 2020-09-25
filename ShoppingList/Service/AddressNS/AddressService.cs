using ShoppingList.DataModel.Request.AddressNS;
using ShoppingList.DataModel.Response.AddressNS;
using ShoppingList.Repository.AddressNS;
using System;

namespace ShoppingList.Service.AddressNS
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

using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.AddressNS;
using ShoppingList.DataModel.Response.AddressNS;
using ShoppingList.Repository.AddressNS;
using ShoppingList.Validation.AddressNS;
using ShoppingList.Validation.Errors;
using System;
using System.Collections.Generic;

namespace ShoppingList.Service.AddressNS
{
    public class AddressService : IAddressService
    {
        readonly IAddress _repository;
        readonly AddressValidation _validation;

        public AddressService(IAddress repository, AddressValidation validation)
        {
            _repository = repository;
            _validation = validation;
        }

        public AddressCreateResponse CreateAddress(AddressCreateRequest createRequest)
        {
            var response = new AddressCreateResponse();
            var validationErrors = _validation.createRequestValidation.Validate(createRequest);
            var dbErrors = new List<DatabaseErrors>();

            if (validationErrors.Count != 0)
            {
                response.ValidationErrors = validationErrors;
            } else
            {
                try
                {
                    var address = AddAddressToDB(createRequest);
                    var addresses = new List<Address>();
                    addresses.Add(address);

                    if (address == null) throw new NullReferenceException("Address not Found");

                    response.Addresses = addresses;
                } catch(NullReferenceException)
                {
                    dbErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                }
                response.DBErrors = dbErrors;
            }
            return response;
        }

        private Address AddAddressToDB(AddressCreateRequest createRequest)
        {
            return _repository.Create(
                new Address
                {
                    Country = createRequest.Country,
                    City = createRequest.City,
                    Street = createRequest.Street,
                    House_Number = createRequest.House_Number,
                    Flat_Number = createRequest.Flat_Number,
                    Additional_Info = createRequest.Additional_Info,
                    Phone = createRequest.Phone,
                    User_Id = createRequest.User_Id
                }
            );
        }
    }
}

using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.Address;

namespace ShoppingList.Service
{
    public interface IAddressService
    {
        AddressCreateResponse CreateAddress(AddressCreateRequest createRequest);
    }
}

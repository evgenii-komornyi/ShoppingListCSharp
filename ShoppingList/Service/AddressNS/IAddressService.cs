using ShoppingList.DataModel.Request.AddressNS;
using ShoppingList.DataModel.Response.AddressNS;

namespace ShoppingList.Service.AddressNS
{
    public interface IAddressService
    {
        AddressCreateResponse CreateAddress(AddressCreateRequest createRequest);
    }
}

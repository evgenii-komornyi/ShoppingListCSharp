using ShoppingList.DataModel.Response.AddressNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.AddressDTO
{
    public class AddressCreateDTO : AddressBasicDTO
    {
        public AddressCreateResponse AddressResponse { get; set; }
    }
}

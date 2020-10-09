using DataTransferObjects.AddressDTO;
using DataTransferObjects.UserDTO;
using ShoppingList.DataModel.Request.AddressNS;
using ShoppingList.DataModel.Request.UserNS;
using ShoppingList.Service.AddressNS;
using ShoppingList.Service.UserNS;
using ShoppingList.Validation.Errors;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ShoppingListAPI.Controllers
{
    [EnableCors(origins: "http://localhost:9000", headers: "*", methods: "*")]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        readonly IUserService _userService;
        readonly IAddressService _addressService;

        public UserController(IAddressService addressService, IUserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }

        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("createUser")]
        public UserCreateDTO PostUser([FromBody]UserCreateRequest userRequest)
        {
            var responseJson = new UserCreateDTO();
            var user = _userService.CreateUser(userRequest);

            if (user.HasValidationErrors() || user.HasDBErrors())
            {
                responseJson.validationErrors = _convertErrorsToString<UserValidationErrors>(user.ValidationErrors);
                responseJson.dbErrors = user.DBErrors;
            } else
            {
                responseJson.UserId = user.User.Id;
            }

            return responseJson;
        }

        [HttpPost]
        [Route("createAddress")]
        public AddressCreateDTO PostAddress([FromBody] AddressCreateRequest addressRequest)
        {
            var responseJson = new AddressCreateDTO();
            var address = _addressService.CreateAddress(addressRequest);

            if (address.HasValidationErrors() || address.HasDBErrors())
            {
                responseJson.validationErrors = _convertErrorsToString<AddressValidationErrors>(address.ValidationErrors);
                responseJson.dbErrors = address.DBErrors;
            }
            else
            {
                responseJson.AddressResponse = address;
            }

            return responseJson;
        } 

        private List<string> _convertErrorsToString<T>(List<T> Errors)
        {
            List<string> convertedErrors = new List<string>();

            if (Errors != null)
            {
                foreach (var error in Errors)
                {
                    convertedErrors.Add(error.ToString());
                }
            }
            return convertedErrors;
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}

using ShoppingList.DataModel;
using ShoppingList.DataModel.Request.UserNS;
using ShoppingList.DataModel.Response.UserNS;
using ShoppingList.Repository.UserNS;
using ShoppingList.Validation.Errors;
using ShoppingList.Validation.UserNS;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ShoppingList.Service.UserNS
{
    public class UserService : IUserService
    {
        readonly IUser _repository;
        readonly UserValidation _validation;

        public UserService(IUser repository, UserValidation validation)
        {
            _repository = repository;
            _validation = validation;
        }

        public UserCreateResponse CreateUser(UserCreateRequest createRequest)
        {
            var response = new UserCreateResponse();
            var validationErrors = _validation.createRequestValidation.Validate(createRequest);
            var DBErrors = new List<DatabaseErrors>();

            if (validationErrors.Count != 0 && validationErrors != null)
            {
                response.ValidationErrors = validationErrors;
            } else
            {
                try
                {
                    var user = AddUserToDB(createRequest);
                    response.User = user;
                }
                catch (NullReferenceException)
                {
                    DBErrors.Add(DatabaseErrors.DB_CONNECTION_FAILED);
                }
                response.DBErrors = DBErrors;
            }

            return response;
        }

        private User AddUserToDB(UserCreateRequest createRequest)
        {
            var salt = GenerateSalt();

            return _repository.Create(
                new User
                {
                    FName = createRequest.FirstName,
                    LName = createRequest.LastName,
                    Birthday = createRequest.Birthday,
                    Email = createRequest.Email,
                    Login = createRequest.Login,
                    Hash = GenerateHashWithSalt(createRequest.Password, salt),
                    Salt = salt,
                    CreationDate = GenerateDate(),
                    Role = "User"
                }
            );
        }

        private string GenerateSalt()
        {
            return Guid.NewGuid().ToString();
        }

        private string GenerateHashWithSalt(string password, string salt)
        {
            salt = salt.Replace("-", "");

            salt = salt.Substring(6, salt.Length - 6);

            salt = salt.Insert(7, "666");
            salt = salt.Insert(salt.Length - 1, "999");

            var algorithm = salt + password;
            
            var saltedHash = Encoding.UTF8.GetBytes(algorithm);
            saltedHash = MD5.Create().ComputeHash(saltedHash);
            return Convert.ToBase64String(saltedHash);
        }

        private DateTime GenerateDate()
        {
            return DateTime.UtcNow;
        }
    }
}

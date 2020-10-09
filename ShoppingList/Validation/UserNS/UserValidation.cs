namespace ShoppingList.Validation.UserNS
{
    public class UserValidation
    {
        public UserCreateRequestValidation createRequestValidation { get; set; }

        public UserValidation(UserCreateRequestValidation createRequestValidation)
        {
            this.createRequestValidation = createRequestValidation;
        }
    }
}

namespace ShoppingList.Validation.AddressNS
{
    public class AddressValidation
    {
        public AddressCreateRequestValidation createRequestValidation { get; set; }

        public AddressValidation(AddressCreateRequestValidation createRequestValidation)
        {
            this.createRequestValidation = createRequestValidation;
        }
    }
}

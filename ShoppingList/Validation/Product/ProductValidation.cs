namespace ShoppingList.Validation.Product
{
    public class ProductValidation
    {
        public CreateRequestValidation CreateRequestValidation;
        public FindRequestValidation FindRequestValidation;
        public UpdateRequestValidation UpdateRequestValidation;
        public DeleteRequestValidation DeleteRequestValidation;

        public ProductValidation(CreateRequestValidation createRequestValidation, FindRequestValidation findRequestValidation,
                                 UpdateRequestValidation updateRequestValidation, DeleteRequestValidation deleteRequestValidation)
        {
            CreateRequestValidation = createRequestValidation;
            FindRequestValidation = findRequestValidation;
            UpdateRequestValidation = updateRequestValidation;
            DeleteRequestValidation = deleteRequestValidation;
        }
    }
}

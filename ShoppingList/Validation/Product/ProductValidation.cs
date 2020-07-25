using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Validation.Product
{
    public class ProductValidation
    {
        public CreateRequestValidation CreateRequestValidation { get; set; }
        public FindRequestValidation FindRequestValidation { get; set; }
        public UpdateRequestValidation UpdateRequestValidation { get; set; }
        public DeleteRequestValidation DeleteRequestValidation { get; set; }

        public ProductValidation(CreateRequestValidation createRequestValidation, FindRequestValidation findRequestValidation, 
            UpdateRequestValidation updateRequestValidation, DeleteRequestValidation deleteRequestValidation)
        {
            this.CreateRequestValidation = createRequestValidation;
            this.FindRequestValidation = findRequestValidation;
            this.UpdateRequestValidation = updateRequestValidation;
            this.DeleteRequestValidation = deleteRequestValidation;
        }
    }
}

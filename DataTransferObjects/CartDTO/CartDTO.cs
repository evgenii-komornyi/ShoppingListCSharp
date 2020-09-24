using ShoppingList.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.CartDTO
{
    public class CartDTO : CartBasicDTO
    {
        public long id { get; set; }
        public List<ProductInCartDTO> products { get; set; }
        public decimal amount { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(id)}={id.ToString()}, {nameof(products)}={products}, {nameof(amount)}={amount.ToString()}, {nameof(status)}={status}, {nameof(validationErrors)}={validationErrors}, {nameof(dbErrors)}={dbErrors}}}";
        }
    }
}

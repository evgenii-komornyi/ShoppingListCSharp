using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel.Request.Product
{
   public class ProductUpdateRequest : ProductBasicRequest
    {
        public long Id { get; set; }
    }
}

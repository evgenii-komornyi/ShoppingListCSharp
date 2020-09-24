using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel.Request.Product
{
    public class ProductFindRequest
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public long Category_Id { get; set; }
    }
}

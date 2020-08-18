using ShoppingList.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.ProductDTO
{
    public class ProductDTO
    {
        public long id { get; set; }
        public string name { get; set; }
        public decimal regPrice { get; set; }
        public string category { get; set; }

        public decimal discount { get; set; }
        public string description { get; set; }
        public decimal actPrice { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(id)}={id.ToString()}, {nameof(name)}={name}, {nameof(regPrice)}={regPrice.ToString()}, {nameof(category)}={category}, {nameof(discount)}={discount.ToString()}, {nameof(description)}={description}, {nameof(actPrice)}={actPrice.ToString()}}}";
        }
    }
}

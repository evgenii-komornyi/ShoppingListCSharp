using ShoppingList.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.ProductDTO
{
    public class ProductDTO : ProductBasicDTO
    {
        public long id { get; set; }
        public string name { get; set; }
        public decimal regPrice { get; set; }
        public string category { get; set; }
        public long category_id { get; set; }

        public decimal discount { get; set; }
        public string description { get; set; }
        public decimal actPrice { get; set; }

        public long file_id { get; set; }
        public string image_path { get; set; }
    }
}

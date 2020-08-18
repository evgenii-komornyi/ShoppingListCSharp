using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel.Request.Product
{
    public abstract class ProductBasicRequest : BasicRequest
    {
        [Required]
        public string Name { get; set; }

        
        public Category Category { get; set; }
        
        [Required]
        public string CategoryString
        {
            get { return Category.ToString(); }
            private set { Category = (Category)Enum.Parse(typeof(Category), value); }
        }

        [Required]
        public decimal Price { get; set; }
        public decimal Discount { get; set; } = 0;
        public string Description { get; set; } = "";
    }
}

using System.ComponentModel.DataAnnotations;

namespace ShoppingList.DataModel.Request.ProductNS
{
    public abstract class ProductBasicRequest : BasicRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public long Category_Id { get; set; }

        [Required]
        public decimal Price { get; set; }
        public decimal Discount { get; set; } = 0;
        public string Description { get; set; } = "";

        public long File_Id { get; set; } = 2;
    }
}

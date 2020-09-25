using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingList.DataModel
{
    [Table("ProductCart", Schema = "dbo")]
    public class ProductCart
    {
        [Key, Column(Order = 1)]
        public long Product_ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Key, Column(Order = 2)]
        public long Cart_CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public int Quantity { get; set; }
    }
}

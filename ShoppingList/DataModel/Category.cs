using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel
{
    [Table("Category", Schema = "dbo")]
    public class Category
    {
        [Key]
        [Column("Category_Id")]
        public long Category_Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}

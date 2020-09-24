using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel
{
    [Table("FileStorage", Schema="dbo")]
    public class FileStorage
    {
        [Key]
        [Column("File_Id")]
        public long File_Id { get; set; }
        
        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        [Column("Name"), MaxLength(50)]
        public string Name { get; set; }
        
        [Column("Category")]
        public string Category { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}

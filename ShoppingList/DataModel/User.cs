using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel
{
    public class User
    {
        [Key]
        public long UserId { get; set; }

        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(15)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        public string Birthday { get; set; }

        [Required]
        [MaxLength(20)]
        [Index("IX_UserUniqueLogin", 1, IsUnique = true)]
        public string Login { get; set; }

        [Required]
        [MaxLength(100)]
        public string MD5 { get; set; }

        [MaxLength(100)]
        public string Salt { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}

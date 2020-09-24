using ShoppingList.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel
{
    [Table("User", Schema = "dbo")]
    public class User
    {
        [Key]
        [Column("Id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("FName")]
        public string FName { get; set; }

        [Required]
        [MaxLength(15)]
        [Column("LName")]
        public string LName { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("Birthday")]
        public string Birthday { get; set; }

        [Required]
        [MaxLength(20)]
        [Index("IX_UserUniqueLogin", 1, IsUnique = true)]
        [Column("Login")]
        public string Login { get; set; }

        [MaxLength(100)]
        [Column("Hash")]
        public string Hash { get; set; }

        [MaxLength(100)]
        [Column("Salt")]
        public string Salt { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("Role")]
        public string Role { get; set; }

        [Column("Address_Address_Id")]
        public long Address_Id { get; set; }

        [ForeignKey("Address_Id")]
        public Address Address { get; set; }
        public virtual List<Address> Addresses { get; set; }
    }
}

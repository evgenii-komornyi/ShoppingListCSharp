using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel
{
    [Table("Address", Schema = "dbo")]
    public class Address
    {
        [Key]
        [Column("Address_Id")]
        public long Address_Id { get; set; }
        
        [Column("Country")]
        public string Country { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("Street")]
        public string Street { get; set; }

        [Column("House_Number")]
        public string House_Number { get; set; }

        [Column("Flat_Number")]
        public string Flat_Number { get; set; }

        [Column("Additional_Info")]
        public string Additional_Info { get; set; }

        [Column("Phone")]
        public string Phone { get; set; }

        [Column("User_Id")]
        public long User_Id { get; set; }
    }
}

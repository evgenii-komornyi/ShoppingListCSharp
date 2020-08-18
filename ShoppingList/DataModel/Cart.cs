using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel
{
    [Table("Cart", Schema = "dbo")]
    public class Cart
    {
        [Key]
        [Column("Id")]
        public long Id { get; set; }
        [Column("User_Id")]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<ProductCart> Products { get; set; }

        public Cart(ICollection<ProductCart> products)
        {
            this.Products = new HashSet<ProductCart>();
        }

        public Cart()
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(UserId)}={UserId.ToString()}, {nameof(User)}={User}, {nameof(Products)}={Products}}}";
        }

        public override bool Equals(object obj)
        {
            return obj is Cart cart &&
                   Id == cart.Id &&
                   UserId == cart.UserId &&
                   EqualityComparer<User>.Default.Equals(User, cart.User) &&
                   EqualityComparer<ICollection<ProductCart>>.Default.Equals(Products, cart.Products);
        }

        public override int GetHashCode()
        {
            int hashCode = -958602946;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + UserId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(User);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<ProductCart>>.Default.GetHashCode(Products);
            return hashCode;
        }
    }
}

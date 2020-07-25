using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel
{
    public class Cart
    {
        [Key]
        public long CartId { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Cart(ICollection<Product> products)
        {
            this.Products = new HashSet<Product>();
        }

        public Cart()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Cart cart &&
                   CartId == cart.CartId &&
                   UserId == cart.UserId &&
                   EqualityComparer<User>.Default.Equals(User, cart.User) &&
                   EqualityComparer<ICollection<Product>>.Default.Equals(Products, cart.Products);
        }

        public override int GetHashCode()
        {
            int hashCode = -1141365904;
            hashCode = hashCode * -1521134295 + CartId.GetHashCode();
            hashCode = hashCode * -1521134295 + UserId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(User);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<Product>>.Default.GetHashCode(Products);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{{nameof(CartId)}={CartId.ToString()}, {nameof(UserId)}={UserId.ToString()}, {nameof(User)}={User}, {nameof(Products)}={Products}}}";
        }
    }
}

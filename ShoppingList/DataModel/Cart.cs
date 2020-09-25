using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public virtual ICollection<ProductCart> ProductsCarts { get; set; }

        public Cart(ICollection<ProductCart> products)
        {
            this.ProductsCarts = new HashSet<ProductCart>();
        }

        public Cart()
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(UserId)}={UserId.ToString()}, {nameof(User)}={User}, {nameof(ProductsCarts)}={ProductsCarts}}}";
        }

        public override bool Equals(object obj)
        {
            return obj is Cart cart &&
                   Id == cart.Id &&
                   UserId == cart.UserId &&
                   EqualityComparer<User>.Default.Equals(User, cart.User) &&
                   EqualityComparer<ICollection<ProductCart>>.Default.Equals(ProductsCarts, cart.ProductsCarts);
        }

        public override int GetHashCode()
        {
            int hashCode = -958602946;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + UserId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(User);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<ProductCart>>.Default.GetHashCode(ProductsCarts);
            return hashCode;
        }
    }
}

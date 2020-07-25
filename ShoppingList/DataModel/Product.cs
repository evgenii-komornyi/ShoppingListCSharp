using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel
{
    public class Product
    {
        public long ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        public string Name { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Decimal Price { get; set; }
        public Decimal Discount { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

        public Product()
        {
        }

        public Product(ICollection<Cart> carts)
        {
            this.Carts = new HashSet<Cart>();
        }
        
        public Product(string name, Category category, decimal price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }

        public Decimal CalculateActualPrice()
        {
            return Decimal.Subtract(Price, Decimal.Multiply(Price, Decimal.Divide(Discount, 100)));
        }

        public override string ToString()
        {
            return $"{{{nameof(ProductId)}={ProductId.ToString()}, {nameof(Name)}={Name}, {nameof(Category)}={Category.ToString()}, {nameof(Price)}={Price.ToString()}, {nameof(Discount)}={Discount.ToString()}, {nameof(Description)}={Description}, {nameof(Carts)}={Carts}}}";
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   ProductId == product.ProductId &&
                   Name == product.Name &&
                   Category == product.Category &&
                   Price == product.Price &&
                   Discount == product.Discount &&
                   Description == product.Description &&
                   EqualityComparer<ICollection<Cart>>.Default.Equals(Carts, product.Carts);
        }

        public override int GetHashCode()
        {
            int hashCode = -586279403;
            hashCode = hashCode * -1521134295 + ProductId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Category.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            hashCode = hashCode * -1521134295 + Discount.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<Cart>>.Default.GetHashCode(Carts);
            return hashCode;
        }
    }
}

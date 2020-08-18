using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel
{
    [Table("Product", Schema = "dbo")]
    public class Product
    {
        [Column("Id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        [Column("Name")]
        public string Name { get; set; }
      
        [NotMapped]
        public Category Category { get; set; }

        [Required]
        [Column("Category")]
        public string CategoryString
        {
            get { return Category.ToString(); }
            private set { Category = (Category)Enum.Parse(typeof(Category), value); }
        }

        [Required]
        [Column("Price")]
        public Decimal Price { get; set; }
        
        [Column("Discount")]
        public Decimal Discount { get; set; }
        
        [Column("Description")]
        public string Description { get; set; }

        public virtual ICollection<ProductCart> ProductCart { get; set; }

        public Product()
        {
        }

        public Product(string name, Category category, decimal price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }

        public Decimal CalculateActualPrice()
        {
            return Decimal.Round(Decimal.Subtract(Price, Decimal.Multiply(Price, Decimal.Divide(Discount, 100))), 2, MidpointRounding.ToEven);
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Category)}={Category.ToString()}, {nameof(Price)}={Price.ToString()}, {nameof(Discount)}={Discount.ToString()}, {nameof(Description)}={Description}, {nameof(ProductCart)}={ProductCart}}}";
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Id == product.Id &&
                   Name == product.Name &&
                   Category == product.Category &&
                   Price == product.Price &&
                   Discount == product.Discount &&
                   Description == product.Description &&
                   EqualityComparer<ICollection<ProductCart>>.Default.Equals(ProductCart, product.ProductCart);
        }

        public override int GetHashCode()
        {
            int hashCode = -1680633502;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Category.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            hashCode = hashCode * -1521134295 + Discount.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<ProductCart>>.Default.GetHashCode(ProductCart);
            return hashCode;
        }
    }
}

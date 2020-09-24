using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.DataModel
{
    [Table("Product", Schema = "dbo")]
    public class Product
    {
        [Key]
        [Column("Id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("Category_Category_Id")]
        public long Category_Id { get; set; }

        [ForeignKey("Category_Id")]
        public virtual Category Category { get; set; }

        [NotMapped]
        public string CategoryName { 
            get { return this.Category != default(Category) ? this.Category.Name : default(string); } 
        }

        [Required]
        [Column("Price")]
        public Decimal Price { get; set; }
        
        [Column("Discount")]
        public Decimal Discount { get; set; }
        
        [Column("Description")]
        public string Description { get; set; }

        [Column("File_File_Id")]
        public long File_Id { get; set; }

        public virtual FileStorage FileStorage { get; set; }

        [NotMapped]
        public string FileName
        {
            get { return this.FileStorage != default(FileStorage) ? this.FileStorage.Name : default(string); }
        }

        public virtual ICollection<ProductCart> ProductCart { get; set; }

        public Product()
        {
        }

        public Product(string name, long category_id, decimal price)
        {
            this.Name = name;
            this.Category_Id = category_id;
            this.Price = price;
        }

        public Decimal CalculateActualPrice()
        {
            return Decimal.Round(Decimal.Subtract(Price, Decimal.Multiply(Price, Decimal.Divide(Discount, 100))), 2, MidpointRounding.ToEven);
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Category_Id)}={Category_Id.ToString()}, {nameof(Category)}={Category}, {nameof(CategoryName)}={CategoryName}, {nameof(Price)}={Price.ToString()}, {nameof(Discount)}={Discount.ToString()}, {nameof(Description)}={Description}, {nameof(File_Id)}={File_Id.ToString()}, {nameof(FileStorage)}={FileStorage}, {nameof(ProductCart)}={ProductCart}}}";
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Id == product.Id &&
                   Name == product.Name &&
                   Category_Id == product.Category_Id &&
                   EqualityComparer<Category>.Default.Equals(Category, product.Category) &&
                   CategoryName == product.CategoryName &&
                   Price == product.Price &&
                   Discount == product.Discount &&
                   Description == product.Description &&
                   File_Id == product.File_Id &&
                   EqualityComparer<FileStorage>.Default.Equals(FileStorage, product.FileStorage) &&
                   EqualityComparer<ICollection<ProductCart>>.Default.Equals(ProductCart, product.ProductCart);
        }

        public override int GetHashCode()
        {
            int hashCode = 635632148;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Category_Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Category>.Default.GetHashCode(Category);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CategoryName);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            hashCode = hashCode * -1521134295 + Discount.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + File_Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<FileStorage>.Default.GetHashCode(FileStorage);
            hashCode = hashCode * -1521134295 + EqualityComparer<ICollection<ProductCart>>.Default.GetHashCode(ProductCart);
            return hashCode;
        }
    }
}

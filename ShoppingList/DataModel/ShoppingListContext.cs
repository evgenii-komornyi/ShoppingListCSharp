namespace ShoppingList.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    public class ShoppingListContext : DbContext
    {
        public ShoppingListContext()
            : base("Name=ShoppingListContext")
        {
        }


        public DbSet<User> User { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCart> ProductCart { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
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


        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
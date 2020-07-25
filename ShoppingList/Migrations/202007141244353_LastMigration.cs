namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Category = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProductId)
                .Index(t => t.Name, unique: true, name: "IX_FirstAndSecond");
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        LastName = c.String(nullable: false, maxLength: 15),
                        Birthday = c.String(nullable: false, maxLength: 20),
                        Login = c.String(nullable: false, maxLength: 20),
                        MD5 = c.String(nullable: false, maxLength: 100),
                        Salt = c.String(maxLength: 100),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.Login, unique: true, name: "IX_UserUniqueLogin");
            
            CreateTable(
                "dbo.ProductCarts",
                c => new
                    {
                        Product_ProductId = c.Long(nullable: false),
                        Cart_CartId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Cart_CartId })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Carts", t => t.Cart_CartId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Cart_CartId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "UserId", "dbo.Users");
            DropForeignKey("dbo.ProductCarts", "Cart_CartId", "dbo.Carts");
            DropForeignKey("dbo.ProductCarts", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.ProductCarts", new[] { "Cart_CartId" });
            DropIndex("dbo.ProductCarts", new[] { "Product_ProductId" });
            DropIndex("dbo.Users", "IX_UserUniqueLogin");
            DropIndex("dbo.Products", "IX_FirstAndSecond");
            DropIndex("dbo.Carts", new[] { "UserId" });
            DropTable("dbo.ProductCarts");
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
        }
    }
}

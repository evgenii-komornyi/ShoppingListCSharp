namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ProductCart",
                c => new
                    {
                        Product_ProductId = c.Long(nullable: false),
                        Cart_CartId = c.Long(nullable: false),
                        Cart_Id = c.Long(),
                        Product_Id = c.Long(),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Cart_CartId })
                .ForeignKey("dbo.Cart", t => t.Cart_Id)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .Index(t => t.Cart_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Category = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_FirstAndSecond");
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        LastName = c.String(nullable: false, maxLength: 15),
                        Birthday = c.String(nullable: false, maxLength: 20),
                        Login = c.String(nullable: false, maxLength: 20),
                        MD5 = c.String(nullable: false, maxLength: 100),
                        Salt = c.String(maxLength: 100),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Login, unique: true, name: "IX_UserUniqueLogin");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "UserId", "dbo.User");
            DropForeignKey("dbo.ProductCart", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.ProductCart", "Cart_Id", "dbo.Cart");
            DropIndex("dbo.User", "IX_UserUniqueLogin");
            DropIndex("dbo.Product", "IX_FirstAndSecond");
            DropIndex("dbo.ProductCart", new[] { "Product_Id" });
            DropIndex("dbo.ProductCart", new[] { "Cart_Id" });
            DropIndex("dbo.Cart", new[] { "UserId" });
            DropTable("dbo.User");
            DropTable("dbo.Product");
            DropTable("dbo.ProductCart");
            DropTable("dbo.Cart");
        }
    }
}

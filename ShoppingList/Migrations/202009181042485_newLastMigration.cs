namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newLastMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        User_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ProductCart",
                c => new
                    {
                        Product_ProductId = c.Long(nullable: false),
                        Cart_CartId = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Cart_Id = c.Long(nullable: false),
                        Product_Id = c.Long(),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Cart_CartId })
                .ForeignKey("dbo.Cart", t => t.Cart_Id, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.Product_Id)
                .Index(t => t.Cart_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Category_Category_Id = c.Long(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        File_File_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.FileStorage", t => t.File_File_Id, cascadeDelete: true)
                .Index(t => t.Name, unique: true, name: "IX_FirstAndSecond")
                .Index(t => t.Category_Category_Id)
                .Index(t => t.File_File_Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Category_Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Category_Id);
            
            CreateTable(
                "dbo.FileStorage",
                c => new
                    {
                        File_Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.File_Id);
            
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
            DropForeignKey("dbo.Cart", "User_Id", "dbo.User");
            DropForeignKey("dbo.ProductCart", "Product_Id", "dbo.Product");
            DropForeignKey("dbo.Product", "File_File_Id", "dbo.FileStorage");
            DropForeignKey("dbo.Product", "Category_Category_Id", "dbo.Category");
            DropForeignKey("dbo.ProductCart", "Cart_Id", "dbo.Cart");
            DropIndex("dbo.User", "IX_UserUniqueLogin");
            DropIndex("dbo.Product", new[] { "File_File_Id" });
            DropIndex("dbo.Product", new[] { "Category_Category_Id" });
            DropIndex("dbo.Product", "IX_FirstAndSecond");
            DropIndex("dbo.ProductCart", new[] { "Product_Id" });
            DropIndex("dbo.ProductCart", new[] { "Cart_Id" });
            DropIndex("dbo.Cart", new[] { "User_Id" });
            DropTable("dbo.User");
            DropTable("dbo.FileStorage");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.ProductCart");
            DropTable("dbo.Cart");
        }
    }
}

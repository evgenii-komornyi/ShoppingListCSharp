namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Product", "Category_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.Product", "Category_Id");
            AddForeignKey("dbo.Product", "Category_Id", "dbo.Category", "Id");
            DropColumn("dbo.Product", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Category", c => c.String(nullable: false));
            DropForeignKey("dbo.Product", "Category_Id1", "dbo.Category");
            DropIndex("dbo.Product", new[] { "Category_Id1" });
            DropColumn("dbo.Product", "Category_Id1");
            DropColumn("dbo.Product", "Category_Id");
            DropTable("dbo.Category");
        }
    }
}

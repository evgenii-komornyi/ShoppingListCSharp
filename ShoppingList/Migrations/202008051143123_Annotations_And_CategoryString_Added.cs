namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Annotations_And_CategoryString_Added : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cart", name: "UserId", newName: "User_Id");
            RenameIndex(table: "dbo.Cart", name: "IX_UserId", newName: "IX_User_Id");
            AlterColumn("dbo.Product", "Category", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Category", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Cart", name: "IX_User_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.Cart", name: "User_Id", newName: "UserId");
        }
    }
}

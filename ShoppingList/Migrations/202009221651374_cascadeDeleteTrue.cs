namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadeDeleteTrue : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "File_File_Id", "dbo.FileStorage");
            DropForeignKey("dbo.Product", "FileStorage_File_Id", "dbo.FileStorage");
            DropIndex("dbo.Product", new[] { "File_File_Id" });
            DropIndex("dbo.Product", new[] { "FileStorage_File_Id" });
            DropColumn("dbo.Product", "File_File_Id");
            RenameColumn(table: "dbo.Product", name: "FileStorage_File_Id", newName: "File_File_Id");
            AlterColumn("dbo.Product", "File_File_Id", c => c.Long(nullable: true));
            CreateIndex("dbo.Product", "File_File_Id");
            AddForeignKey("dbo.Product", "File_File_Id", "dbo.FileStorage", "File_Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "File_File_Id", "dbo.FileStorage");
            DropIndex("dbo.Product", new[] { "File_File_Id" });
            AlterColumn("dbo.Product", "File_File_Id", c => c.Long());
            RenameColumn(table: "dbo.Product", name: "File_File_Id", newName: "FileStorage_File_Id");
            AddColumn("dbo.Product", "File_File_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.Product", "FileStorage_File_Id");
            CreateIndex("dbo.Product", "File_File_Id");
            AddForeignKey("dbo.Product", "FileStorage_File_Id", "dbo.FileStorage", "File_Id");
            AddForeignKey("dbo.Product", "File_File_Id", "dbo.FileStorage", "File_Id");
        }
    }
}

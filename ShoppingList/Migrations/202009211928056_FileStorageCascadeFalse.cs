namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileStorageCascadeFalse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "File_File_Id", "dbo.FileStorage");
            AddColumn("dbo.Product", "FileStorage_File_Id", c => c.Long());
            CreateIndex("dbo.Product", "FileStorage_File_Id");
            AddForeignKey("dbo.Product", "File_File_Id", "dbo.FileStorage", "File_Id");
            AddForeignKey("dbo.Product", "FileStorage_File_Id", "dbo.FileStorage", "File_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "FileStorage_File_Id", "dbo.FileStorage");
            DropForeignKey("dbo.Product", "File_File_Id", "dbo.FileStorage");
            DropIndex("dbo.Product", new[] { "FileStorage_File_Id" });
            DropColumn("dbo.Product", "FileStorage_File_Id");
            AddForeignKey("dbo.Product", "File_File_Id", "dbo.FileStorage", "File_Id", cascadeDelete: true);
        }
    }
}

namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maxLengthFileName50 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FileStorage", "Name", c => c.String(maxLength: 50));
            CreateIndex("dbo.FileStorage", "Name", unique: true, name: "IX_FirstAndSecond");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FileStorage", "IX_FirstAndSecond");
            AlterColumn("dbo.FileStorage", "Name", c => c.String());
        }
    }
}

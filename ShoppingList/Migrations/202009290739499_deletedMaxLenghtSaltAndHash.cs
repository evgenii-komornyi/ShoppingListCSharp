namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedMaxLenghtSaltAndHash : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Hash", c => c.String());
            AlterColumn("dbo.User", "Salt", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Salt", c => c.String(maxLength: 100));
            AlterColumn("dbo.User", "Hash", c => c.String(maxLength: 100));
        }
    }
}

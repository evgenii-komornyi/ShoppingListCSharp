namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wasChangedLengthNameBirthday : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "FName", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.User", "Birthday", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Birthday", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.User", "FName", c => c.String(nullable: false, maxLength: 10));
        }
    }
}

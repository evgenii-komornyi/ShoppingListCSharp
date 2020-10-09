namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wasAddedEmailToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Email", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Email");
        }
    }
}

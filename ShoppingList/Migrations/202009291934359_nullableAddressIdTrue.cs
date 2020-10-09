namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableAddressIdTrue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Address_Address_Id", c => c.Long(nullable: true));
        }
        
        public override void Down()
        {   
            AlterColumn("dbo.User", "Address_Address_Id", c => c.Long(nullable: false));
        }
    }
}

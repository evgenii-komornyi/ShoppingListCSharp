namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser_Addresses_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Address_Id = c.Long(nullable: false, identity: true),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        House_Number = c.String(),
                        Flat_Number = c.String(),
                        Additional_Info = c.String(),
                        Phone = c.String(),
                        User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Address_Id)
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: false)
                .Index(t => t.User_Id);
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "MD5", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.User", "LastName", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.User", "FirstName", c => c.String(nullable: false, maxLength: 10));
            DropForeignKey("dbo.Address", "User_Id", "dbo.User");
            DropIndex("dbo.Address", new[] { "User_Id" });
            DropColumn("dbo.User", "DefAddr_Id");
            DropColumn("dbo.User", "Hash");
            DropColumn("dbo.User", "LName");
            DropColumn("dbo.User", "FName");
            DropTable("dbo.Address");
        }
    }
}

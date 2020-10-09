namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressID_In_User : DbMigration
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
                        User_Id = c.Long()
                    })
                .PrimaryKey(t => t.Address_Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            DropColumn("dbo.User", "Address_Address_Id");
            AddColumn("dbo.User", "Address_Address_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.User", "Address_Address_Id");
            AddForeignKey("dbo.User", "Address_Address_Id", "dbo.Address", "Address_Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "MD5", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.User", "LastName", c => c.String(nullable: false, maxLength: 15));
            AddColumn("dbo.User", "FirstName", c => c.String(nullable: false, maxLength: 10));
            DropForeignKey("dbo.Address", "User_Id1", "dbo.User");
            DropForeignKey("dbo.User", "Address_Address_Id", "dbo.Address");
            DropIndex("dbo.User", new[] { "Address_Address_Id" });
            DropIndex("dbo.Address", new[] { "User_Id1" });
            DropColumn("dbo.User", "Address_Address_Id");
            DropColumn("dbo.User", "Hash");
            DropColumn("dbo.User", "LName");
            DropColumn("dbo.User", "FName");
            DropTable("dbo.Address");
        }
    }
}

namespace VideoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemapping5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Customers_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Customers_Id" });
            DropColumn("dbo.Rentals", "Id");
            RenameColumn(table: "dbo.Rentals", name: "Customers_Id", newName: "Id");
            DropPrimaryKey("dbo.Rentals");
            AlterColumn("dbo.Rentals", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Rentals", "Id");
            CreateIndex("dbo.Rentals", "Id");
            AddForeignKey("dbo.Rentals", "Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Id" });
            DropPrimaryKey("dbo.Rentals");
            AlterColumn("dbo.Rentals", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Rentals", "Id");
            RenameColumn(table: "dbo.Rentals", name: "Id", newName: "Customers_Id");
            AddColumn("dbo.Rentals", "Id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Rentals", "Customers_Id");
            AddForeignKey("dbo.Rentals", "Customers_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}

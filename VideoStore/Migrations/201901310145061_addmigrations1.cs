namespace VideoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrations1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerFormViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        IsSubscribed = c.Boolean(nullable: false),
                        MembershipTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId);
            
            AddColumn("dbo.MembershipTypes", "CustomerFormViewModel_Id", c => c.Int());
            CreateIndex("dbo.MembershipTypes", "CustomerFormViewModel_Id");
            AddForeignKey("dbo.MembershipTypes", "CustomerFormViewModel_Id", "dbo.CustomerFormViewModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MembershipTypes", "CustomerFormViewModel_Id", "dbo.CustomerFormViewModels");
            DropForeignKey("dbo.CustomerFormViewModels", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.MembershipTypes", new[] { "CustomerFormViewModel_Id" });
            DropIndex("dbo.CustomerFormViewModels", new[] { "MembershipTypeId" });
            DropColumn("dbo.MembershipTypes", "CustomerFormViewModel_Id");
            DropTable("dbo.CustomerFormViewModels");
        }
    }
}

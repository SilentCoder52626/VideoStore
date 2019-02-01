namespace VideoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MoviesFormViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                        MoviesGenreId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MoviesGenres", t => t.MoviesGenreId, cascadeDelete: true)
                .Index(t => t.MoviesGenreId);
            
            AddColumn("dbo.MoviesGenres", "MoviesFormViewModel_Id", c => c.Int());
            CreateIndex("dbo.MoviesGenres", "MoviesFormViewModel_Id");
            AddForeignKey("dbo.MoviesGenres", "MoviesFormViewModel_Id", "dbo.MoviesFormViewModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MoviesGenres", "MoviesFormViewModel_Id", "dbo.MoviesFormViewModels");
            DropForeignKey("dbo.MoviesFormViewModels", "MoviesGenreId", "dbo.MoviesGenres");
            DropIndex("dbo.MoviesFormViewModels", new[] { "MoviesGenreId" });
            DropIndex("dbo.MoviesGenres", new[] { "MoviesFormViewModel_Id" });
            DropColumn("dbo.MoviesGenres", "MoviesFormViewModel_Id");
            DropTable("dbo.MoviesFormViewModels");
        }
    }
}

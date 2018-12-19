namespace OdeToFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Restaurents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestaurentReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(),
                        RestaurentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurents", t => t.RestaurentId, cascadeDelete: true)
                .Index(t => t.RestaurentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurentReviews", "RestaurentId", "dbo.Restaurents");
            DropIndex("dbo.RestaurentReviews", new[] { "RestaurentId" });
            DropTable("dbo.RestaurentReviews");
            DropTable("dbo.Restaurents");
        }
    }
}

namespace EFDBAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requestModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        requestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Brand = c.String(),
                        InitialPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.requestId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Requests", new[] { "CategoryId" });
            DropTable("dbo.Requests");
        }
    }
}

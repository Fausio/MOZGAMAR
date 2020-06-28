namespace EFDBAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setIsAvailible_to_product : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IsAvailable", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "IsNew", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "IsFeatured");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "IsFeatured", c => c.Boolean());
            AlterColumn("dbo.Products", "IsNew", c => c.Boolean());
            AlterColumn("dbo.Products", "Price", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Products", "IsAvailable");
        }
    }
}

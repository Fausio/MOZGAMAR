namespace EFDBAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_Brand_tp_product : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Brand", c => c.String(maxLength: 30));
            AlterColumn("dbo.Products", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
            DropColumn("dbo.Products", "Brand");
        }
    }
}

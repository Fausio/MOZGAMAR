namespace EFDBAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nullable_updateDate_of_product : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ModifiedDate", c => c.DateTime(nullable: false));
        }
    }
}

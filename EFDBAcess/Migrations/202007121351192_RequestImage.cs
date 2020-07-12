namespace EFDBAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "RequestImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "RequestImage");
        }
    }
}

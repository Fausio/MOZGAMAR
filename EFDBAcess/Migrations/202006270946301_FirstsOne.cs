namespace EFDBAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstsOne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarStatus",
                c => new
                    {
                        CarStatusId = c.Int(nullable: false, identity: true),
                        CarStatusType = c.String(),
                    })
                .PrimaryKey(t => t.CarStatusId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        PoductId = c.Int(),
                        MemberID = c.Int(),
                        CarStatusId = c.Int(),
                        Poduct_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.Products", t => t.Poduct_ProductId)
                .Index(t => t.Poduct_ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(),
                        IsActive = c.Boolean(),
                        ISDelete = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Description = c.String(),
                        ProductImage = c.String(),
                        IsFeatured = c.Boolean(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(),
                        IsNew = c.Boolean(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(),
                        ISDelete = c.Boolean(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        Fistname = c.String(),
                        lastname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        isActive = c.Boolean(),
                        isDelete = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.ShippingDetails",
                c => new
                    {
                        ShippingDetailsId = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(),
                        Addres = c.String(),
                        City = c.String(),
                        Sate = c.String(),
                        Country = c.String(),
                        ZipCode = c.String(),
                        OrderId = c.Int(),
                        AmoutPaId = c.Decimal(precision: 18, scale: 2),
                        PaymentType = c.String(),
                    })
                .PrimaryKey(t => t.ShippingDetailsId)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.MemberRoles",
                c => new
                    {
                        MemberRoleId = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(),
                        RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.MemberRoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.SlideImages",
                c => new
                    {
                        SlideImageId = c.Int(nullable: false, identity: true),
                        SlideTitle = c.String(),
                        SlideImage1 = c.String(),
                    })
                .PrimaryKey(t => t.SlideImageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShippingDetails", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Carts", "Poduct_ProductId", "dbo.Products");
            DropIndex("dbo.ShippingDetails", new[] { "MemberId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Carts", new[] { "Poduct_ProductId" });
            DropTable("dbo.SlideImages");
            DropTable("dbo.Roles");
            DropTable("dbo.MemberRoles");
            DropTable("dbo.ShippingDetails");
            DropTable("dbo.Members");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
            DropTable("dbo.CarStatus");
        }
    }
}

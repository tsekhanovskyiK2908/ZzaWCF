namespace Zza.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductOption",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Factor = c.Int(nullable: false),
                        IsPizzaOption = c.Boolean(nullable: false),
                        IsSaladOption = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Image = c.String(),
                        HasOptions = c.Boolean(nullable: false),
                        IsVegetarian = c.Boolean(nullable: false),
                        WithTomatoSauce = c.Boolean(nullable: false),
                        SizeIds = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductSize",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PremiumPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToppingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsGlutenFree = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductSize");
            DropTable("dbo.Product");
            DropTable("dbo.ProductOption");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Customer");
        }
    }
}

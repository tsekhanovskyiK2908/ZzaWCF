namespace Zza.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateOrdersAndOrderItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StoreId = c.Guid(nullable: true),
                        OrderId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductSizeId = c.Int(nullable: true),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Instructions = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.ProductSize", t => t.ProductSizeId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId)
                .Index(t => t.ProductSizeId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerId = c.Guid(nullable: true),
                        OrderStatusId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        Phone = c.String(maxLength: 100),
                        DeliveryDate = c.DateTime(nullable: true),
                        DeliveryCharge = c.Decimal(nullable: true, precision: 18, scale: 2),
                        DeliveryStreet = c.String(maxLength: 100),
                        DeliveryCity = c.String(maxLength: 100),
                        DeliveryState = c.String(maxLength: 2),
                        DeliveryZip = c.String(maxLength: 10),
                        ItemsTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatusId)
                .Index(t => t.CustomerId)
                .Index(t => t.OrderStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItem", "ProductSizeId", "dbo.ProductSize");
            DropForeignKey("dbo.OrderItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderItem", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order", "OrderStatusId", "dbo.OrderStatus");
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Order", new[] { "OrderStatusId" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropIndex("dbo.OrderItem", new[] { "ProductSizeId" });
            DropIndex("dbo.OrderItem", new[] { "ProductId" });
            DropIndex("dbo.OrderItem", new[] { "OrderId" });
            DropTable("dbo.Order");
            DropTable("dbo.OrderItem");
        }
    }
}

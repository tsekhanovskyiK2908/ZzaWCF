namespace Zza.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderItemOptions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItemOption",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StoreId = c.Guid(nullable: true),
                        OrderItemId = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderItem", t => t.OrderItemId)
                .Index(t => t.OrderItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItemOption", "OrderItemId", "dbo.OrderItem");
            DropIndex("dbo.OrderItemOption", new[] { "OrderItemId" });
            DropTable("dbo.OrderItemOption");
        }
    }
}

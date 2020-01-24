namespace Zza.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductOptionToOrderItemOption : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItemOption", "ProductOptionId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItemOption", "ProductOptionId");
            AddForeignKey("dbo.OrderItemOption", "ProductOptionId", "dbo.ProductOption", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItemOption", "ProductOptionId", "dbo.ProductOption");
            DropIndex("dbo.OrderItemOption", new[] { "ProductOptionId" });
            DropColumn("dbo.OrderItemOption", "ProductOptionId");
        }
    }
}

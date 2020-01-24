namespace Zza.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreIdToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "StoreId", c => c.Guid(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "StoreId");
        }
    }
}

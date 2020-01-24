namespace Zza.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateOrderTables : DbMigration
    {
        public override void Up()
        {
            SqlFile(@"E:\Courses\Pluralsight\WCF\ZzaApplicationWCF\Zza.DataAccessLayer\PopulateTables2.sql");
        }
        
        public override void Down()
        {
        }
    }
}

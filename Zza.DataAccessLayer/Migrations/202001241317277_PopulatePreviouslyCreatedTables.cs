namespace Zza.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePreviouslyCreatedTables : DbMigration
    {
        public override void Up()
        {
            SqlFile(@"E:\Courses\Pluralsight\WCF\ZzaApplicationWCF\Zza.DataAccessLayer\PopulateTables1.sql");
        }
        
        public override void Down()
        {
        }
    }
}

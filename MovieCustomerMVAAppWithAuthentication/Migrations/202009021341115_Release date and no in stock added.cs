namespace MovieCustomerMVAAppWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Releasedateandnoinstockadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NoInStocks", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NoInStocks");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}

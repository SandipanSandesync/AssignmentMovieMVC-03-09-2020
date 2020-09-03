namespace MovieCustomerMVAAppWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YOBColumnaddincustomertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "YearOfBirth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "YearOfBirth");
        }
    }
}

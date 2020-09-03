namespace MovieCustomerMVAAppWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YOBColumndeletedincustomertable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "YearOfBirth");
            DropColumn("dbo.Customers", "DateOFBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "DateOFBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "YearOfBirth", c => c.Int(nullable: false));
        }
    }
}

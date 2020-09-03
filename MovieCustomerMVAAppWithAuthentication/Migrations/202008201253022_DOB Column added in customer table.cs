namespace MovieCustomerMVAAppWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DOBColumnaddedincustomertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DateOFBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DateOFBirth");
        }
    }
}

namespace MovieCustomerMVAAppWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DOBaddedincustomerstableaccordingly : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "YearOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "YearOfBirth", c => c.Int(nullable: false));
        }
    }
}

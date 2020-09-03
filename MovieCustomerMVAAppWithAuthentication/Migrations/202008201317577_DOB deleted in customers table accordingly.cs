namespace MovieCustomerMVAAppWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DOBdeletedincustomerstableaccordingly : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "YearOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "YearOfBirth", c => c.DateTime(nullable: false));
        }
    }
}

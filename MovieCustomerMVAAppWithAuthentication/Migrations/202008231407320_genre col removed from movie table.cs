namespace MovieCustomerMVAAppWithAuthentication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genrecolremovedfrommovietable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String());
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
    }
}

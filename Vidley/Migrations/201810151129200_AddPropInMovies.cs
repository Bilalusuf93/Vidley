namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropInMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "dateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "QtyStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "QtyStock");
            DropColumn("dbo.Movies", "dateTime");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}

namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiscountProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberShipTypes", "Discount", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MemberShipTypes", "Discount");
        }
    }
}

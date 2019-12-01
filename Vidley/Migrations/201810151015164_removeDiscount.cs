namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeDiscount : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.MemberShipTypes", "DiscountRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberShipTypes", "DiscountRate", c => c.Byte(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}

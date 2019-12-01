namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemebersNameProp : DbMigration
    {
        public override void Up()
        {
            Sql("Update MemberShipTypes Set Name='Pay as You go' Where Id=1");
            Sql("Update MemberShipTypes Set Name='Monthly' Where Id=2");
            Sql("Update MemberShipTypes Set Name='Quaterly' Where Id=3");
            Sql("Update MemberShipTypes Set Name='Yearly' Where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}

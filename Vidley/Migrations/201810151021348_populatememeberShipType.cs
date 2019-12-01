namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatememeberShipType : DbMigration
    {
        public override void Up()
        {
            //Sql("Insert INTO MemberShipTypes (Id , SighnUpFee, DurationMonths, Discount) VALUES (1, 0, 0, 0)");
            //Sql("Insert INTO MemberShipTypes (Id , SighnUpFee, DurationMonths, Discount) VALUES (2, 30, 1, 10)");
            //Sql("Insert INTO MemberShipTypes (Id , SighnUpFee, DurationMonths, Discount) VALUES (3, 90, 3, 15)");
            //Sql("Insert INTO MemberShipTypes (Id , SighnUpFee, DurationMonths, Discount) VALUES (4, 300, 12, 20)");
            Sql("Update  MemberShipTypes set Discount=0 where Id=1" );
            Sql("Update  MemberShipTypes set Discount=10 where Id=2");
            Sql("Update  MemberShipTypes set Discount=15 where Id=3");
            Sql("Update  MemberShipTypes set Discount=20 where Id=4");
        }
        
        public override void Down()
        {

        }
    }
}

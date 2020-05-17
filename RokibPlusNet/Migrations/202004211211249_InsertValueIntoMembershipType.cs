namespace RokibPlusNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertValueIntoMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(MembershipName,SignUpFee,DurationInMonths,DiscountRate) VALUES('Pay As You Go',0,0,0)");
            Sql("INSERT INTO MembershipTypes(MembershipName,SignUpFee,DurationInMonths,DiscountRate) VALUES('Monthly',30,1,10)");
            Sql("INSERT INTO MembershipTypes(MembershipName,SignUpFee,DurationInMonths,DiscountRate) VALUES('Quarantly',90,3,15)");
            Sql("INSERT INTO MembershipTypes(MembershipName,SignUpFee,DurationInMonths,DiscountRate) VALUES('Yearly',300,12,20)");
            //Sql("INSERT INTO MembershipTypes(MembershipName,SignUpFee,DurationInMonths,DiscountRate) VALUES('Pay You Go',0,0,0)");
        }

        public override void Down()
        {
        }
    }
}

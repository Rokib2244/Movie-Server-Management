namespace RokibPlusNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipName='Quarterly'  WHERE MembershipTypeId=3");
            Sql("UPDATE MembershipTypes SET MembershipName='Annual'  WHERE MembershipTypeId=4");
        }
        
        public override void Down()
        {
        }
    }
}

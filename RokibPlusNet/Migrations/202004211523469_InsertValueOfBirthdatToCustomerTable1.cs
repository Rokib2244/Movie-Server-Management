namespace RokibPlusNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertValueOfBirthdatToCustomerTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate='4/4/1985' WHERE CustomerId=1");
        }
        
        public override void Down()
        {
        }
    }
}

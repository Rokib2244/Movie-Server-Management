namespace RokibPlusNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertValueIntoCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers(CustomerName,IsSubscribedToNewslatter,MembershipTypeId) VALUES('Arick', 1,1)");
            Sql("INSERT INTO Customers(CustomerName,IsSubscribedToNewslatter,MembershipTypeId) VALUES('Michel', 1,3)");
            Sql("INSERT INTO Customers(CustomerName,IsSubscribedToNewslatter,MembershipTypeId) VALUES('Mbappe', 0,2)");
            Sql("INSERT INTO Customers(CustomerName,IsSubscribedToNewslatter,MembershipTypeId) VALUES('Fardin khan', 0,4)");
        }
        
        public override void Down()
        {
        }
    }
}

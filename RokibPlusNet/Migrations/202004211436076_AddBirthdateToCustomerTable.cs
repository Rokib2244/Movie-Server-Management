﻿namespace RokibPlusNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdateToCustomerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}

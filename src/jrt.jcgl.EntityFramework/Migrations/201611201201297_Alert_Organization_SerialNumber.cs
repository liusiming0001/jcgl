namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alert_Organization_SerialNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "SerialNumber", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "SerialNumber");
        }
    }
}

namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alert_Organization_OrganizationType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizations", "Type", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizations", "Type", c => c.Int(nullable: false));
        }
    }
}

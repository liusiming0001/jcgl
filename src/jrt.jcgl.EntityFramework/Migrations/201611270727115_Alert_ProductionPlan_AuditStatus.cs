namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alert_ProductionPlan_AuditStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductionPlans", "AuditStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductionPlans", "AuditStatus");
        }
    }
}

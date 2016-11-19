namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alert_ProductionPlan_StartDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductionPlans", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.ProductionPlans", "StarDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductionPlans", "StarDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.ProductionPlans", "StartDate");
        }
    }
}

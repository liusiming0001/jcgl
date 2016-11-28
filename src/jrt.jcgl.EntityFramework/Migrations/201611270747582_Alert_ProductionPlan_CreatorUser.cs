namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alert_ProductionPlan_CreatorUser : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ProductionPlans", "DeleterUserId");
            CreateIndex("dbo.ProductionPlans", "LastModifierUserId");
            CreateIndex("dbo.ProductionPlans", "CreatorUserId");
            AddForeignKey("dbo.ProductionPlans", "CreatorUserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.ProductionPlans", "DeleterUserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.ProductionPlans", "LastModifierUserId", "dbo.AbpUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductionPlans", "LastModifierUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.ProductionPlans", "DeleterUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.ProductionPlans", "CreatorUserId", "dbo.AbpUsers");
            DropIndex("dbo.ProductionPlans", new[] { "CreatorUserId" });
            DropIndex("dbo.ProductionPlans", new[] { "LastModifierUserId" });
            DropIndex("dbo.ProductionPlans", new[] { "DeleterUserId" });
        }
    }
}

namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alert_ProductionPlanAudit_AuditRoleId_And_ProductionBatchDetail_ProductionPlan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductionPlanAudits", "AuditRole_Id", "dbo.AbpRoles");
            DropForeignKey("dbo.ProductionBatchDetails", "ProductionPlan_Id", "dbo.ProductionPlans");
            DropIndex("dbo.ProductionBatchDetails", new[] { "ProductionPlan_Id" });
            DropIndex("dbo.ProductionPlanAudits", new[] { "AuditRole_Id" });
            DropColumn("dbo.ProductionPlanAudits", "AuditRoleId");
            RenameColumn(table: "dbo.ProductionPlanAudits", name: "AuditRole_Id", newName: "AuditRoleId");
            RenameColumn(table: "dbo.ProductionBatchDetails", name: "ProductionPlan_Id", newName: "ProductionPlanId");
            AlterColumn("dbo.ProductionBatchDetails", "ProductionPlanId", c => c.Long(nullable: false));
            AlterColumn("dbo.ProductionPlanAudits", "AuditRoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductionPlanAudits", "AuditRoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductionBatchDetails", "ProductionPlanId");
            CreateIndex("dbo.ProductionPlanAudits", "AuditRoleId");
            AddForeignKey("dbo.ProductionPlanAudits", "AuditRoleId", "dbo.AbpRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductionBatchDetails", "ProductionPlanId", "dbo.ProductionPlans", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductionBatchDetails", "ProductionPlanId", "dbo.ProductionPlans");
            DropForeignKey("dbo.ProductionPlanAudits", "AuditRoleId", "dbo.AbpRoles");
            DropIndex("dbo.ProductionPlanAudits", new[] { "AuditRoleId" });
            DropIndex("dbo.ProductionBatchDetails", new[] { "ProductionPlanId" });
            AlterColumn("dbo.ProductionPlanAudits", "AuditRoleId", c => c.Int());
            AlterColumn("dbo.ProductionPlanAudits", "AuditRoleId", c => c.Long(nullable: false));
            AlterColumn("dbo.ProductionBatchDetails", "ProductionPlanId", c => c.Long());
            RenameColumn(table: "dbo.ProductionBatchDetails", name: "ProductionPlanId", newName: "ProductionPlan_Id");
            RenameColumn(table: "dbo.ProductionPlanAudits", name: "AuditRoleId", newName: "AuditRole_Id");
            AddColumn("dbo.ProductionPlanAudits", "AuditRoleId", c => c.Long(nullable: false));
            CreateIndex("dbo.ProductionPlanAudits", "AuditRole_Id");
            CreateIndex("dbo.ProductionBatchDetails", "ProductionPlan_Id");
            AddForeignKey("dbo.ProductionBatchDetails", "ProductionPlan_Id", "dbo.ProductionPlans", "Id");
            AddForeignKey("dbo.ProductionPlanAudits", "AuditRole_Id", "dbo.AbpRoles", "Id");
        }
    }
}

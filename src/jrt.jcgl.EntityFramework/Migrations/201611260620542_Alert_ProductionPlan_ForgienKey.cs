namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alert_ProductionPlan_ForgienKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductionBatchDetails", "ProductionPlanId", "dbo.ProductionPlans");
            DropForeignKey("dbo.ProductionBatchDetails", "RawMaterialId", "dbo.RawMaterials");
            DropForeignKey("dbo.ProductionPlanAudits", "ProductionPlanId", "dbo.ProductionPlans");
            DropForeignKey("dbo.ProduictPlanLines", "ProductionPlanId", "dbo.ProductionPlans");
            DropForeignKey("dbo.ProdutionPlanMains", "ProductionPlanId", "dbo.ProductionPlans");
            DropForeignKey("dbo.ProductionPlanAudits", "AuditRoleId", "dbo.AbpRoles");
            DropForeignKey("dbo.ProductionPlanAudits", "AuditUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.ProduictPlanLines", "OrganizationUnitId", "dbo.AbpOrganizationUnits");
            DropForeignKey("dbo.ProdutionPlanMains", "RawMaterialId", "dbo.RawMaterials");
            DropForeignKey("dbo.ProdutionPlanMains", "StockId", "dbo.Stocks");
            DropIndex("dbo.ProductionBatchDetails", new[] { "ProductionPlanId" });
            DropIndex("dbo.ProductionBatchDetails", new[] { "RawMaterialId" });
            DropIndex("dbo.ProductionPlanAudits", new[] { "ProductionPlanId" });
            DropIndex("dbo.ProductionPlanAudits", new[] { "AuditUserId" });
            DropIndex("dbo.ProductionPlanAudits", new[] { "AuditRoleId" });
            DropIndex("dbo.ProduictPlanLines", new[] { "ProductionPlanId" });
            DropIndex("dbo.ProduictPlanLines", new[] { "OrganizationUnitId" });
            DropIndex("dbo.ProdutionPlanMains", new[] { "ProductionPlanId" });
            DropIndex("dbo.ProdutionPlanMains", new[] { "StockId" });
            DropIndex("dbo.ProdutionPlanMains", new[] { "RawMaterialId" });
            AlterColumn("dbo.ProductionBatchDetails", "ProductionPlanId", c => c.Long());
            AlterColumn("dbo.ProductionBatchDetails", "RawMaterialId", c => c.Int());
            AlterColumn("dbo.ProductionPlanAudits", "ProductionPlanId", c => c.Long());
            AlterColumn("dbo.ProductionPlanAudits", "AuditUserId", c => c.Long());
            AlterColumn("dbo.ProductionPlanAudits", "AuditRoleId", c => c.Int());
            AlterColumn("dbo.ProduictPlanLines", "ProductionPlanId", c => c.Long());
            AlterColumn("dbo.ProduictPlanLines", "OrganizationUnitId", c => c.Long());
            AlterColumn("dbo.ProdutionPlanMains", "ProductionPlanId", c => c.Long());
            AlterColumn("dbo.ProdutionPlanMains", "StockId", c => c.Int());
            AlterColumn("dbo.ProdutionPlanMains", "RawMaterialId", c => c.Int());
            CreateIndex("dbo.ProductionBatchDetails", "ProductionPlanId");
            CreateIndex("dbo.ProductionBatchDetails", "RawMaterialId");
            CreateIndex("dbo.ProductionPlanAudits", "ProductionPlanId");
            CreateIndex("dbo.ProductionPlanAudits", "AuditUserId");
            CreateIndex("dbo.ProductionPlanAudits", "AuditRoleId");
            CreateIndex("dbo.ProduictPlanLines", "ProductionPlanId");
            CreateIndex("dbo.ProduictPlanLines", "OrganizationUnitId");
            CreateIndex("dbo.ProdutionPlanMains", "ProductionPlanId");
            CreateIndex("dbo.ProdutionPlanMains", "StockId");
            CreateIndex("dbo.ProdutionPlanMains", "RawMaterialId");
            AddForeignKey("dbo.ProductionBatchDetails", "ProductionPlanId", "dbo.ProductionPlans", "Id");
            AddForeignKey("dbo.ProductionBatchDetails", "RawMaterialId", "dbo.RawMaterials", "Id");
            AddForeignKey("dbo.ProductionPlanAudits", "ProductionPlanId", "dbo.ProductionPlans", "Id");
            AddForeignKey("dbo.ProduictPlanLines", "ProductionPlanId", "dbo.ProductionPlans", "Id");
            AddForeignKey("dbo.ProdutionPlanMains", "ProductionPlanId", "dbo.ProductionPlans", "Id");
            AddForeignKey("dbo.ProductionPlanAudits", "AuditRoleId", "dbo.AbpRoles", "Id");
            AddForeignKey("dbo.ProductionPlanAudits", "AuditUserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.ProduictPlanLines", "OrganizationUnitId", "dbo.AbpOrganizationUnits", "Id");
            AddForeignKey("dbo.ProdutionPlanMains", "RawMaterialId", "dbo.RawMaterials", "Id");
            AddForeignKey("dbo.ProdutionPlanMains", "StockId", "dbo.Stocks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutionPlanMains", "StockId", "dbo.Stocks");
            DropForeignKey("dbo.ProdutionPlanMains", "RawMaterialId", "dbo.RawMaterials");
            DropForeignKey("dbo.ProduictPlanLines", "OrganizationUnitId", "dbo.AbpOrganizationUnits");
            DropForeignKey("dbo.ProductionPlanAudits", "AuditUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.ProductionPlanAudits", "AuditRoleId", "dbo.AbpRoles");
            DropForeignKey("dbo.ProdutionPlanMains", "ProductionPlanId", "dbo.ProductionPlans");
            DropForeignKey("dbo.ProduictPlanLines", "ProductionPlanId", "dbo.ProductionPlans");
            DropForeignKey("dbo.ProductionPlanAudits", "ProductionPlanId", "dbo.ProductionPlans");
            DropForeignKey("dbo.ProductionBatchDetails", "RawMaterialId", "dbo.RawMaterials");
            DropForeignKey("dbo.ProductionBatchDetails", "ProductionPlanId", "dbo.ProductionPlans");
            DropIndex("dbo.ProdutionPlanMains", new[] { "RawMaterialId" });
            DropIndex("dbo.ProdutionPlanMains", new[] { "StockId" });
            DropIndex("dbo.ProdutionPlanMains", new[] { "ProductionPlanId" });
            DropIndex("dbo.ProduictPlanLines", new[] { "OrganizationUnitId" });
            DropIndex("dbo.ProduictPlanLines", new[] { "ProductionPlanId" });
            DropIndex("dbo.ProductionPlanAudits", new[] { "AuditRoleId" });
            DropIndex("dbo.ProductionPlanAudits", new[] { "AuditUserId" });
            DropIndex("dbo.ProductionPlanAudits", new[] { "ProductionPlanId" });
            DropIndex("dbo.ProductionBatchDetails", new[] { "RawMaterialId" });
            DropIndex("dbo.ProductionBatchDetails", new[] { "ProductionPlanId" });
            AlterColumn("dbo.ProdutionPlanMains", "RawMaterialId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProdutionPlanMains", "StockId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProdutionPlanMains", "ProductionPlanId", c => c.Long(nullable: false));
            AlterColumn("dbo.ProduictPlanLines", "OrganizationUnitId", c => c.Long(nullable: false));
            AlterColumn("dbo.ProduictPlanLines", "ProductionPlanId", c => c.Long(nullable: false));
            AlterColumn("dbo.ProductionPlanAudits", "AuditRoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductionPlanAudits", "AuditUserId", c => c.Long(nullable: false));
            AlterColumn("dbo.ProductionPlanAudits", "ProductionPlanId", c => c.Long(nullable: false));
            AlterColumn("dbo.ProductionBatchDetails", "RawMaterialId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductionBatchDetails", "ProductionPlanId", c => c.Long(nullable: false));
            CreateIndex("dbo.ProdutionPlanMains", "RawMaterialId");
            CreateIndex("dbo.ProdutionPlanMains", "StockId");
            CreateIndex("dbo.ProdutionPlanMains", "ProductionPlanId");
            CreateIndex("dbo.ProduictPlanLines", "OrganizationUnitId");
            CreateIndex("dbo.ProduictPlanLines", "ProductionPlanId");
            CreateIndex("dbo.ProductionPlanAudits", "AuditRoleId");
            CreateIndex("dbo.ProductionPlanAudits", "AuditUserId");
            CreateIndex("dbo.ProductionPlanAudits", "ProductionPlanId");
            CreateIndex("dbo.ProductionBatchDetails", "RawMaterialId");
            CreateIndex("dbo.ProductionBatchDetails", "ProductionPlanId");
            AddForeignKey("dbo.ProdutionPlanMains", "StockId", "dbo.Stocks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProdutionPlanMains", "RawMaterialId", "dbo.RawMaterials", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProduictPlanLines", "OrganizationUnitId", "dbo.AbpOrganizationUnits", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductionPlanAudits", "AuditUserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductionPlanAudits", "AuditRoleId", "dbo.AbpRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProdutionPlanMains", "ProductionPlanId", "dbo.ProductionPlans", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProduictPlanLines", "ProductionPlanId", "dbo.ProductionPlans", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductionPlanAudits", "ProductionPlanId", "dbo.ProductionPlans", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductionBatchDetails", "RawMaterialId", "dbo.RawMaterials", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductionBatchDetails", "ProductionPlanId", "dbo.ProductionPlans", "Id", cascadeDelete: true);
        }
    }
}

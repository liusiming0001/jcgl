namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alert_Stocks_Productions_RawMaterial_ForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProduictPlanLines", "ProdutionPlanMainId", "dbo.ProdutionPlanMains");
            DropForeignKey("dbo.ProductionPlanAudits", "ProductionPlan_Id", "dbo.ProductionPlans");
            DropIndex("dbo.ProductionPlanAudits", new[] { "ProductionPlan_Id" });
            DropIndex("dbo.ProduictPlanLines", new[] { "ProdutionPlanMainId" });
            RenameColumn(table: "dbo.ProductionPlanAudits", name: "ProductionPlan_Id", newName: "ProductionPlanId");
            AddColumn("dbo.ProductionBatchDetails", "ProductionPlan_Id", c => c.Long());
            AddColumn("dbo.ProduictPlanLines", "ProductionPlanId", c => c.Long(nullable: false));
            AddColumn("dbo.ProdutionPlanMains", "ProductionPlanId", c => c.Long(nullable: false));
            AlterColumn("dbo.ProductionPlanAudits", "ProductionPlanId", c => c.Long(nullable: false));
            CreateIndex("dbo.ProductionBatchDetails", "ProductionPlan_Id");
            CreateIndex("dbo.ProductionPlanAudits", "ProductionPlanId");
            CreateIndex("dbo.ProduictPlanLines", "ProductionPlanId");
            CreateIndex("dbo.ProdutionPlanMains", "ProductionPlanId");
            AddForeignKey("dbo.ProductionBatchDetails", "ProductionPlan_Id", "dbo.ProductionPlans", "Id");
            AddForeignKey("dbo.ProduictPlanLines", "ProductionPlanId", "dbo.ProductionPlans", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProdutionPlanMains", "ProductionPlanId", "dbo.ProductionPlans", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductionPlanAudits", "ProductionPlanId", "dbo.ProductionPlans", "Id", cascadeDelete: true);
            DropColumn("dbo.ProduictPlanLines", "ProdutionPlanMainId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProduictPlanLines", "ProdutionPlanMainId", c => c.Long(nullable: false));
            DropForeignKey("dbo.ProductionPlanAudits", "ProductionPlanId", "dbo.ProductionPlans");
            DropForeignKey("dbo.ProdutionPlanMains", "ProductionPlanId", "dbo.ProductionPlans");
            DropForeignKey("dbo.ProduictPlanLines", "ProductionPlanId", "dbo.ProductionPlans");
            DropForeignKey("dbo.ProductionBatchDetails", "ProductionPlan_Id", "dbo.ProductionPlans");
            DropIndex("dbo.ProdutionPlanMains", new[] { "ProductionPlanId" });
            DropIndex("dbo.ProduictPlanLines", new[] { "ProductionPlanId" });
            DropIndex("dbo.ProductionPlanAudits", new[] { "ProductionPlanId" });
            DropIndex("dbo.ProductionBatchDetails", new[] { "ProductionPlan_Id" });
            AlterColumn("dbo.ProductionPlanAudits", "ProductionPlanId", c => c.Long());
            DropColumn("dbo.ProdutionPlanMains", "ProductionPlanId");
            DropColumn("dbo.ProduictPlanLines", "ProductionPlanId");
            DropColumn("dbo.ProductionBatchDetails", "ProductionPlan_Id");
            RenameColumn(table: "dbo.ProductionPlanAudits", name: "ProductionPlanId", newName: "ProductionPlan_Id");
            CreateIndex("dbo.ProduictPlanLines", "ProdutionPlanMainId");
            CreateIndex("dbo.ProductionPlanAudits", "ProductionPlan_Id");
            AddForeignKey("dbo.ProductionPlanAudits", "ProductionPlan_Id", "dbo.ProductionPlans", "Id");
            AddForeignKey("dbo.ProduictPlanLines", "ProdutionPlanMainId", "dbo.ProdutionPlanMains", "Id", cascadeDelete: true);
        }
    }
}

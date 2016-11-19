namespace jrt.jcgl.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Stocks_Productions_RawMaterial_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductionBatchDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SerailNum = c.Int(nullable: false),
                        RawMaterialId = c.Int(nullable: false),
                        BatchNum = c.String(),
                        ProductionLineCount = c.Int(nullable: false),
                        Mission = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MissionDate = c.DateTime(nullable: false),
                        CYL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SGL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProductionBatchDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RawMaterials", t => t.RawMaterialId, cascadeDelete: true)
                .Index(t => t.RawMaterialId);
            
            CreateTable(
                "dbo.RawMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BatchNumber = c.String(),
                        Producer = c.String(),
                        Manufacturer = c.String(),
                        Supplier = c.String(),
                        Level = c.String(),
                        Specifications = c.String(),
                        Units = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RawMaterial_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RawMaterialConstants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RawMaterialId = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Constant = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RawMaterialConstant_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RawMaterials", t => t.RawMaterialId, cascadeDelete: true)
                .Index(t => t.RawMaterialId);
            
            CreateTable(
                "dbo.ProductionPlanAudits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AuditUserId = c.Long(nullable: false),
                        AuditRoleId = c.Long(nullable: false),
                        AuditTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        AuditRole_Id = c.Int(),
                        ProductionPlan_Id = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProductionPlanAudit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpRoles", t => t.AuditRole_Id)
                .ForeignKey("dbo.AbpUsers", t => t.AuditUserId, cascadeDelete: true)
                .ForeignKey("dbo.ProductionPlans", t => t.ProductionPlan_Id)
                .Index(t => t.AuditUserId)
                .Index(t => t.AuditRole_Id)
                .Index(t => t.ProductionPlan_Id);
            
            CreateTable(
                "dbo.ProductionPlans",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Demand = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StarDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProductionPlan_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProduictPlanLines",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProdutionPlanMainId = c.Long(nullable: false),
                        OrganizationUnitId = c.Long(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProduictPlanLine_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpOrganizationUnits", t => t.OrganizationUnitId, cascadeDelete: true)
                .ForeignKey("dbo.ProdutionPlanMains", t => t.ProdutionPlanMainId, cascadeDelete: true)
                .Index(t => t.ProdutionPlanMainId)
                .Index(t => t.OrganizationUnitId);
            
            CreateTable(
                "dbo.ProdutionPlanMains",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PlannedQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductionQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PS = c.Int(nullable: false),
                        RawMaterialRequirement = c.Int(nullable: false),
                        StockId = c.Int(nullable: false),
                        RawMaterialId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProdutionPlanMain_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RawMaterials", t => t.RawMaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Stocks", t => t.StockId, cascadeDelete: true)
                .Index(t => t.StockId)
                .Index(t => t.RawMaterialId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RawMaterialId = c.Int(),
                        StockValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Stock_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RawMaterials", t => t.RawMaterialId)
                .Index(t => t.RawMaterialId);
            
            CreateTable(
                "dbo.StockLogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StockId = c.Int(nullable: false),
                        Quality = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HandleUserId = c.Long(),
                        HandleTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_StockLog_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.HandleUserId)
                .ForeignKey("dbo.Stocks", t => t.StockId, cascadeDelete: true)
                .Index(t => t.StockId)
                .Index(t => t.HandleUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutionPlanMains", "StockId", "dbo.Stocks");
            DropForeignKey("dbo.StockLogs", "StockId", "dbo.Stocks");
            DropForeignKey("dbo.StockLogs", "HandleUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.Stocks", "RawMaterialId", "dbo.RawMaterials");
            DropForeignKey("dbo.ProdutionPlanMains", "RawMaterialId", "dbo.RawMaterials");
            DropForeignKey("dbo.ProduictPlanLines", "ProdutionPlanMainId", "dbo.ProdutionPlanMains");
            DropForeignKey("dbo.ProduictPlanLines", "OrganizationUnitId", "dbo.AbpOrganizationUnits");
            DropForeignKey("dbo.ProductionPlanAudits", "ProductionPlan_Id", "dbo.ProductionPlans");
            DropForeignKey("dbo.ProductionPlanAudits", "AuditUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.ProductionPlanAudits", "AuditRole_Id", "dbo.AbpRoles");
            DropForeignKey("dbo.ProductionBatchDetails", "RawMaterialId", "dbo.RawMaterials");
            DropForeignKey("dbo.RawMaterialConstants", "RawMaterialId", "dbo.RawMaterials");
            DropIndex("dbo.StockLogs", new[] { "HandleUserId" });
            DropIndex("dbo.StockLogs", new[] { "StockId" });
            DropIndex("dbo.Stocks", new[] { "RawMaterialId" });
            DropIndex("dbo.ProdutionPlanMains", new[] { "RawMaterialId" });
            DropIndex("dbo.ProdutionPlanMains", new[] { "StockId" });
            DropIndex("dbo.ProduictPlanLines", new[] { "OrganizationUnitId" });
            DropIndex("dbo.ProduictPlanLines", new[] { "ProdutionPlanMainId" });
            DropIndex("dbo.ProductionPlanAudits", new[] { "ProductionPlan_Id" });
            DropIndex("dbo.ProductionPlanAudits", new[] { "AuditRole_Id" });
            DropIndex("dbo.ProductionPlanAudits", new[] { "AuditUserId" });
            DropIndex("dbo.RawMaterialConstants", new[] { "RawMaterialId" });
            DropIndex("dbo.ProductionBatchDetails", new[] { "RawMaterialId" });
            DropTable("dbo.StockLogs",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_StockLog_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Stocks",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Stock_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ProdutionPlanMains",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProdutionPlanMain_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ProduictPlanLines",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProduictPlanLine_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ProductionPlans",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProductionPlan_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ProductionPlanAudits",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProductionPlanAudit_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.RawMaterialConstants",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RawMaterialConstant_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.RawMaterials",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RawMaterial_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ProductionBatchDetails",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProductionBatchDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}

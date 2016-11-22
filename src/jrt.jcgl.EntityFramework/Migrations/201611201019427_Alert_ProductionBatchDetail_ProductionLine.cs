namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alert_ProductionBatchDetail_ProductionLine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductionBatchDetails", "ProductionLine", c => c.String());
            AddColumn("dbo.ProdutionPlanMains", "SerialNumber", c => c.Int(nullable: false));
            DropColumn("dbo.ProductionBatchDetails", "ProductionLineCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductionBatchDetails", "ProductionLineCount", c => c.Int(nullable: false));
            DropColumn("dbo.ProdutionPlanMains", "SerialNumber");
            DropColumn("dbo.ProductionBatchDetails", "ProductionLine");
        }
    }
}

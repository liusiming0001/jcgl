namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alert_ProductionBatchDetail_MissionQuantityAndBatchQuantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductionBatchDetails", "MissionQuantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProductionBatchDetails", "BatchQuantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ProductionBatchDetails", "Mission");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductionBatchDetails", "Mission", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ProductionBatchDetails", "BatchQuantity");
            DropColumn("dbo.ProductionBatchDetails", "MissionQuantity");
        }
    }
}

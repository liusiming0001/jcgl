namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alert_RawMaterialConstant_RawMaterialId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RawMaterialConstants", "RawMaterialId", "dbo.RawMaterials");
            DropIndex("dbo.RawMaterialConstants", new[] { "RawMaterialId" });
            AlterColumn("dbo.RawMaterialConstants", "RawMaterialId", c => c.Int());
            CreateIndex("dbo.RawMaterialConstants", "RawMaterialId");
            AddForeignKey("dbo.RawMaterialConstants", "RawMaterialId", "dbo.RawMaterials", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RawMaterialConstants", "RawMaterialId", "dbo.RawMaterials");
            DropIndex("dbo.RawMaterialConstants", new[] { "RawMaterialId" });
            AlterColumn("dbo.RawMaterialConstants", "RawMaterialId", c => c.Int(nullable: false));
            CreateIndex("dbo.RawMaterialConstants", "RawMaterialId");
            AddForeignKey("dbo.RawMaterialConstants", "RawMaterialId", "dbo.RawMaterials", "Id", cascadeDelete: true);
        }
    }
}

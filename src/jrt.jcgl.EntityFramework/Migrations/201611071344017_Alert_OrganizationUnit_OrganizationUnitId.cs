namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alert_OrganizationUnit_OrganizationUnitId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Organizations", "OrganizationUnit_Id", "dbo.AbpOrganizationUnits");
            DropIndex("dbo.Organizations", new[] { "OrganizationUnit_Id" });
            RenameColumn(table: "dbo.Organizations", name: "OrganizationUnit_Id", newName: "OrganizationUnitId");
            AlterColumn("dbo.Organizations", "OrganizationUnitId", c => c.Long(nullable: false));
            CreateIndex("dbo.Organizations", "OrganizationUnitId");
            AddForeignKey("dbo.Organizations", "OrganizationUnitId", "dbo.AbpOrganizationUnits", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizations", "OrganizationUnitId", "dbo.AbpOrganizationUnits");
            DropIndex("dbo.Organizations", new[] { "OrganizationUnitId" });
            AlterColumn("dbo.Organizations", "OrganizationUnitId", c => c.Long());
            RenameColumn(table: "dbo.Organizations", name: "OrganizationUnitId", newName: "OrganizationUnit_Id");
            CreateIndex("dbo.Organizations", "OrganizationUnit_Id");
            AddForeignKey("dbo.Organizations", "OrganizationUnit_Id", "dbo.AbpOrganizationUnits", "Id");
        }
    }
}

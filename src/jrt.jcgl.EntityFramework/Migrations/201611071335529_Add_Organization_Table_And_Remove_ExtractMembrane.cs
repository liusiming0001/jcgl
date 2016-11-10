namespace jrt.jcgl.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Organization_Table_And_Remove_ExtractMembrane : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        OrganizationUnit_Id = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Organization_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpOrganizationUnits", t => t.OrganizationUnit_Id)
                .Index(t => t.OrganizationUnit_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizations", "OrganizationUnit_Id", "dbo.AbpOrganizationUnits");
            DropIndex("dbo.Organizations", new[] { "OrganizationUnit_Id" });
            DropTable("dbo.Organizations",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Organization_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}

namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alert_Scheduling_ExtractMember_And_MembraneMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedulings", "ExtractMember_Id", c => c.Long());
            AddColumn("dbo.Schedulings", "MembraneMember_Id", c => c.Long());
            CreateIndex("dbo.Schedulings", "ExtractMember_Id");
            CreateIndex("dbo.Schedulings", "MembraneMember_Id");
            AddForeignKey("dbo.Schedulings", "ExtractMember_Id", "dbo.AbpOrganizationUnits", "Id");
            AddForeignKey("dbo.Schedulings", "MembraneMember_Id", "dbo.AbpOrganizationUnits", "Id");
            DropColumn("dbo.Schedulings", "ExtractMember");
            DropColumn("dbo.Schedulings", "MembraneMember");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedulings", "MembraneMember", c => c.String());
            AddColumn("dbo.Schedulings", "ExtractMember", c => c.String());
            DropForeignKey("dbo.Schedulings", "MembraneMember_Id", "dbo.AbpOrganizationUnits");
            DropForeignKey("dbo.Schedulings", "ExtractMember_Id", "dbo.AbpOrganizationUnits");
            DropIndex("dbo.Schedulings", new[] { "MembraneMember_Id" });
            DropIndex("dbo.Schedulings", new[] { "ExtractMember_Id" });
            DropColumn("dbo.Schedulings", "MembraneMember_Id");
            DropColumn("dbo.Schedulings", "ExtractMember_Id");
        }
    }
}

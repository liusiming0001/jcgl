namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alert_Scheduling_ForgienerKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Schedulings", name: "ExtractMember_Id", newName: "ExtractMemberId");
            RenameColumn(table: "dbo.Schedulings", name: "MembraneMember_Id", newName: "MembraneMemberId");
            RenameIndex(table: "dbo.Schedulings", name: "IX_ExtractMember_Id", newName: "IX_ExtractMemberId");
            RenameIndex(table: "dbo.Schedulings", name: "IX_MembraneMember_Id", newName: "IX_MembraneMemberId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Schedulings", name: "IX_MembraneMemberId", newName: "IX_MembraneMember_Id");
            RenameIndex(table: "dbo.Schedulings", name: "IX_ExtractMemberId", newName: "IX_ExtractMember_Id");
            RenameColumn(table: "dbo.Schedulings", name: "MembraneMemberId", newName: "MembraneMember_Id");
            RenameColumn(table: "dbo.Schedulings", name: "ExtractMemberId", newName: "ExtractMember_Id");
        }
    }
}

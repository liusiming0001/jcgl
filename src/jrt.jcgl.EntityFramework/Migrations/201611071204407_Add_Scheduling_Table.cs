namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Scheduling_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedulings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SchedulingDate = c.DateTime(nullable: false),
                        ExtractBatchNum = c.String(),
                        ExtractMember = c.String(),
                        ExtractWorkInfo = c.String(),
                        MembraneBatchNum = c.String(),
                        MembraneMember = c.String(),
                        MembraneWorkInfo = c.String(),
                        MedicinalName = c.String(),
                        WorkType = c.Int(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Schedulings");
        }
    }
}

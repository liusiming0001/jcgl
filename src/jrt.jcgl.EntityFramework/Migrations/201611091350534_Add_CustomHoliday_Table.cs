namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_CustomHoliday_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomHolidays",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Holiday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomHolidays");
        }
    }
}

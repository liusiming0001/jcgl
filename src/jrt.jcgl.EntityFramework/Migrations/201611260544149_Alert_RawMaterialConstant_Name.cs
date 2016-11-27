
namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alert_RawMaterialConstant_Name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RawMaterialConstants", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RawMaterialConstants", "Name");
        }
    }
}

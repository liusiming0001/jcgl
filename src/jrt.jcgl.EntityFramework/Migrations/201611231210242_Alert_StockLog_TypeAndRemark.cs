namespace jrt.jcgl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alert_StockLog_TypeAndRemark : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockLogs", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.StockLogs", "Remark", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockLogs", "Remark");
            DropColumn("dbo.StockLogs", "Type");
        }
    }
}

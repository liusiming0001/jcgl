namespace IMTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IMTEST : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IMAppKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Key = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IMFriends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FriendID = c.Long(nullable: false),
                        FromID = c.Long(nullable: false),
                        ToUserID = c.Long(nullable: false),
                        Type = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IMGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        AdminUserID = c.Long(nullable: false),
                        GroupName = c.String(),
                        GroupNioce = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IMGroupMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupMessageID = c.Long(nullable: false),
                        FromUserID = c.Long(nullable: false),
                        ToGroupID = c.Int(nullable: false),
                        Message = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IMGroupRelationships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        UserID = c.Long(nullable: false),
                        Type = c.Int(nullable: false),
                        GroupMessageType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IMGroups", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.IMMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageID = c.Long(nullable: false),
                        FromUserID = c.Long(nullable: false),
                        ToUserID = c.Long(nullable: false),
                        MessageInfo = c.String(),
                        Type = c.Int(nullable: false),
                        CrearteTime = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IMUsers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AppKey = c.String(),
                        Icon = c.String(),
                        Phone = c.String(),
                        PassWord = c.String(),
                        Role = c.Int(nullable: false),
                        NickName = c.String(),
                        UserType = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        CreateUserID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IMGroupRelationships", "GroupID", "dbo.IMGroups");
            DropIndex("dbo.IMGroupRelationships", new[] { "GroupID" });
            DropTable("dbo.IMUsers");
            DropTable("dbo.IMMessages");
            DropTable("dbo.IMGroupRelationships");
            DropTable("dbo.IMGroupMessages");
            DropTable("dbo.IMGroups");
            DropTable("dbo.IMFriends");
            DropTable("dbo.IMAppKeys");
        }
    }
}

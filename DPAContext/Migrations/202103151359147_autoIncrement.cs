namespace DPAContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autoIncrement : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "requestId", "dbo.Request");
            DropForeignKey("dbo.Request", "stateId", "dbo.State");
            DropForeignKey("dbo.Comment", "userId", "dbo.User");
            DropForeignKey("dbo.Request", "userId", "dbo.User");
            DropForeignKey("dbo.User", "roleId", "dbo.Role");
            DropPrimaryKey("dbo.Comment");
            DropPrimaryKey("dbo.Request");
            DropPrimaryKey("dbo.State");
            DropPrimaryKey("dbo.User");
            DropPrimaryKey("dbo.Role");
            AlterColumn("dbo.Comment", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Request", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.State", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.User", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Role", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Comment", "id");
            AddPrimaryKey("dbo.Request", "id");
            AddPrimaryKey("dbo.State", "id");
            AddPrimaryKey("dbo.User", "id");
            AddPrimaryKey("dbo.Role", "id");
            AddForeignKey("dbo.Comment", "requestId", "dbo.Request", "id");
            AddForeignKey("dbo.Request", "stateId", "dbo.State", "id");
            AddForeignKey("dbo.Comment", "userId", "dbo.User", "id");
            AddForeignKey("dbo.Request", "userId", "dbo.User", "id");
            AddForeignKey("dbo.User", "roleId", "dbo.Role", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "roleId", "dbo.Role");
            DropForeignKey("dbo.Request", "userId", "dbo.User");
            DropForeignKey("dbo.Comment", "userId", "dbo.User");
            DropForeignKey("dbo.Request", "stateId", "dbo.State");
            DropForeignKey("dbo.Comment", "requestId", "dbo.Request");
            DropPrimaryKey("dbo.Role");
            DropPrimaryKey("dbo.User");
            DropPrimaryKey("dbo.State");
            DropPrimaryKey("dbo.Request");
            DropPrimaryKey("dbo.Comment");
            AlterColumn("dbo.Role", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.State", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Request", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Comment", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Role", "id");
            AddPrimaryKey("dbo.User", "id");
            AddPrimaryKey("dbo.State", "id");
            AddPrimaryKey("dbo.Request", "id");
            AddPrimaryKey("dbo.Comment", "id");
            AddForeignKey("dbo.User", "roleId", "dbo.Role", "id");
            AddForeignKey("dbo.Request", "userId", "dbo.User", "id");
            AddForeignKey("dbo.Comment", "userId", "dbo.User", "id");
            AddForeignKey("dbo.Request", "stateId", "dbo.State", "id");
            AddForeignKey("dbo.Comment", "requestId", "dbo.Request", "id");
        }
    }
}

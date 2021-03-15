namespace DPAContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        body = c.String(maxLength: 250),
                        dateComment = c.DateTime(),
                        userId = c.Int(),
                        requestId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Request", t => t.requestId)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.requestId);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(maxLength: 250),
                        requestDate = c.DateTime(),
                        flag = c.String(maxLength: 50),
                        documentId = c.Int(),
                        userId = c.Int(),
                        commentId = c.Int(),
                        stateId = c.Int(),
                        createdAt = c.DateTime(),
                        updatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Document", t => t.documentId)
                .ForeignKey("dbo.State", t => t.stateId)
                .ForeignKey("dbo.User", t => t.userId)
                .Index(t => t.documentId)
                .Index(t => t.userId)
                .Index(t => t.stateId);
            
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type = c.String(maxLength: 50),
                        description = c.String(maxLength: 250),
                        state = c.String(maxLength: 50),
                        createdAt = c.DateTime(),
                        updatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50),
                        description = c.String(maxLength: 250),
                        createdAt = c.DateTime(),
                        updatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(maxLength: 50),
                        lastName = c.String(maxLength: 50),
                        email = c.String(maxLength: 255),
                        password = c.String(maxLength: 255),
                        state = c.Byte(),
                        createdAt = c.DateTime(),
                        updatedAt = c.DateTime(),
                        roleId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Role", t => t.roleId)
                .Index(t => t.roleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50),
                        description = c.String(maxLength: 250),
                        createdAt = c.DateTime(),
                        updatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UserRequestComment",
                c => new
                    {
                        idRequest = c.Int(nullable: false),
                        idUser = c.Int(nullable: false),
                        idComment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idRequest, t.idUser, t.idComment });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "roleId", "dbo.Role");
            DropForeignKey("dbo.Request", "userId", "dbo.User");
            DropForeignKey("dbo.Comment", "userId", "dbo.User");
            DropForeignKey("dbo.Request", "stateId", "dbo.State");
            DropForeignKey("dbo.Request", "documentId", "dbo.Document");
            DropForeignKey("dbo.Comment", "requestId", "dbo.Request");
            DropIndex("dbo.User", new[] { "roleId" });
            DropIndex("dbo.Request", new[] { "stateId" });
            DropIndex("dbo.Request", new[] { "userId" });
            DropIndex("dbo.Request", new[] { "documentId" });
            DropIndex("dbo.Comment", new[] { "requestId" });
            DropIndex("dbo.Comment", new[] { "userId" });
            DropTable("dbo.UserRequestComment");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.State");
            DropTable("dbo.Document");
            DropTable("dbo.Request");
            DropTable("dbo.Comment");
        }
    }
}

namespace demandeAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        body = c.String(),
                        dateComment = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.States");
            DropTable("dbo.Roles");
            DropTable("dbo.Documents");
            DropTable("dbo.Comments");
        }
    }
}

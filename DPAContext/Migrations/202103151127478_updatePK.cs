namespace DPAContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Request", "documentId", "dbo.Document");
            DropPrimaryKey("dbo.Document");
            AlterColumn("dbo.Document", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Document", "id");
            AddForeignKey("dbo.Request", "documentId", "dbo.Document", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Request", "documentId", "dbo.Document");
            DropPrimaryKey("dbo.Document");
            AlterColumn("dbo.Document", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Document", "id");
            AddForeignKey("dbo.Request", "documentId", "dbo.Document", "id");
        }
    }
}

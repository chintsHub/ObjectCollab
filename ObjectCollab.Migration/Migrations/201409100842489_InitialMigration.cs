namespace ObjectCollab.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataObjectHierarchy",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ParentId = c.Int(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataObjectHierarchy", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.DataObject",
                c => new
                    {
                        DataObjectId = c.Int(nullable: false, identity: true),
                        DataObjectLabel = c.String(nullable: false),
                        GroupId = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        DataObjectGroup_Id = c.Int(),
                    })
                .PrimaryKey(t => t.DataObjectId)
                .ForeignKey("dbo.DataObjectHierarchy", t => t.DataObjectGroup_Id)
                .ForeignKey("dbo.DataObjectHierarchy", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.DataObjectGroup_Id);
            
            CreateTable(
                "dbo.ColumnDefinition",
                c => new
                    {
                        ColumnId = c.Int(nullable: false, identity: true),
                        SourceColumn = c.String(nullable: false),
                        Label = c.String(nullable: false),
                        OleDbDataObjectId = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ColumnId)
                .ForeignKey("dbo.OleDbObject", t => t.OleDbDataObjectId)
                .Index(t => t.OleDbDataObjectId);
            
            CreateTable(
                "dbo.OleDbConnection",
                c => new
                    {
                        ConnectionId = c.Int(nullable: false, identity: true),
                        ConnectionName = c.String(nullable: false),
                        ConnectionString = c.String(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Provider = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConnectionId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.OleDbObject",
                c => new
                    {
                        DataObjectId = c.Int(nullable: false),
                        ConnectionId = c.Int(nullable: false),
                        ObjectName = c.String(nullable: false),
                        WhereClause = c.String(),
                        OledbProvider = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DataObjectId)
                .ForeignKey("dbo.DataObject", t => t.DataObjectId)
                .ForeignKey("dbo.OleDbConnection", t => t.ConnectionId)
                .Index(t => t.DataObjectId)
                .Index(t => t.ConnectionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OleDbObject", "ConnectionId", "dbo.OleDbConnection");
            DropForeignKey("dbo.OleDbObject", "DataObjectId", "dbo.DataObject");
            DropForeignKey("dbo.DataObjectHierarchy", "ParentId", "dbo.DataObjectHierarchy");
            DropForeignKey("dbo.DataObject", "GroupId", "dbo.DataObjectHierarchy");
            DropForeignKey("dbo.DataObject", "DataObjectGroup_Id", "dbo.DataObjectHierarchy");
            DropForeignKey("dbo.ColumnDefinition", "OleDbDataObjectId", "dbo.OleDbObject");
            DropIndex("dbo.OleDbObject", new[] { "ConnectionId" });
            DropIndex("dbo.OleDbObject", new[] { "DataObjectId" });
            DropIndex("dbo.ColumnDefinition", new[] { "OleDbDataObjectId" });
            DropIndex("dbo.DataObject", new[] { "DataObjectGroup_Id" });
            DropIndex("dbo.DataObject", new[] { "GroupId" });
            DropIndex("dbo.DataObjectHierarchy", new[] { "ParentId" });
            DropTable("dbo.OleDbObject");
            DropTable("dbo.User");
            DropTable("dbo.OleDbConnection");
            DropTable("dbo.ColumnDefinition");
            DropTable("dbo.DataObject");
            DropTable("dbo.DataObjectHierarchy");
        }
    }
}

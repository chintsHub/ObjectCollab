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
                        DataObjectType = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.DataObjectId)
                .ForeignKey("dbo.DataObjectHierarchy", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.DataObjectHierarchy", "ParentId", "dbo.DataObjectHierarchy");
            DropForeignKey("dbo.DataObject", "GroupId", "dbo.DataObjectHierarchy");
            DropForeignKey("dbo.ColumnDefinition", "OleDbDataObjectId", "dbo.OleDbObject");
            DropIndex("dbo.OleDbObject", new[] { "ConnectionId" });
            DropIndex("dbo.OleDbObject", new[] { "DataObjectId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ColumnDefinition", new[] { "OleDbDataObjectId" });
            DropIndex("dbo.DataObject", new[] { "GroupId" });
            DropIndex("dbo.DataObjectHierarchy", new[] { "ParentId" });
            DropTable("dbo.OleDbObject");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OleDbConnection");
            DropTable("dbo.ColumnDefinition");
            DropTable("dbo.DataObject");
            DropTable("dbo.DataObjectHierarchy");
        }
    }
}

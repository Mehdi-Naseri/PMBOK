namespace Pmbok.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Management.Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Title = c.String(nullable: false, maxLength: 500),
                        Message = c.String(nullable: false, maxLength: 500),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ProjectDocuments.ProjectDocumentFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false),
                        File = c.Binary(nullable: false),
                        UploadDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(nullable: false),
                        ProjectDocumentId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Projects.Project", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("ProjectDocuments.ProjectDocument", t => t.ProjectDocumentId, cascadeDelete: true)
                .Index(t => t.ProjectDocumentId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "Projects.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        StartDate = c.DateTime(storeType: "date"),
                        EndDate = c.DateTime(storeType: "date"),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "ProjectDocuments.ProjectDocument",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentName = c.String(nullable: false, maxLength: 50),
                        DocumentType = c.String(nullable: false, maxLength: 50),
                        ParentDocumentName = c.String(maxLength: 50),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ProjectDocuments.ProjectDocumentFileDeleted",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false),
                        File = c.Binary(nullable: false),
                        UploadDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DeleteDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(nullable: false),
                        ProjectDocumentId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Projects.Project", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("ProjectDocuments.ProjectDocument", t => t.ProjectDocumentId, cascadeDelete: true)
                .Index(t => t.ProjectDocumentId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "ProjectDocuments.ProjectDocumentValue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(nullable: false),
                        ProjectDocumentId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Projects.Project", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("ProjectDocuments.ProjectDocument", t => t.ProjectDocumentId, cascadeDelete: true)
                .Index(t => t.ProjectDocumentId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "Identity.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "Identity.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("Identity.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Identity.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "Identity.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "Identity.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Identity.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Identity.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("Identity.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Identity.AspNetUserRoles", "UserId", "Identity.AspNetUsers");
            DropForeignKey("Identity.AspNetUserLogins", "UserId", "Identity.AspNetUsers");
            DropForeignKey("Identity.AspNetUserClaims", "UserId", "Identity.AspNetUsers");
            DropForeignKey("Identity.AspNetUserRoles", "RoleId", "Identity.AspNetRoles");
            DropForeignKey("ProjectDocuments.ProjectDocumentValue", "ProjectDocumentId", "ProjectDocuments.ProjectDocument");
            DropForeignKey("ProjectDocuments.ProjectDocumentValue", "ProjectId", "Projects.Project");
            DropForeignKey("ProjectDocuments.ProjectDocumentFileDeleted", "ProjectDocumentId", "ProjectDocuments.ProjectDocument");
            DropForeignKey("ProjectDocuments.ProjectDocumentFileDeleted", "ProjectId", "Projects.Project");
            DropForeignKey("ProjectDocuments.ProjectDocumentFile", "ProjectDocumentId", "ProjectDocuments.ProjectDocument");
            DropForeignKey("ProjectDocuments.ProjectDocumentFile", "ProjectId", "Projects.Project");
            DropIndex("Identity.AspNetUserLogins", new[] { "UserId" });
            DropIndex("Identity.AspNetUserClaims", new[] { "UserId" });
            DropIndex("Identity.AspNetUsers", "UserNameIndex");
            DropIndex("Identity.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("Identity.AspNetUserRoles", new[] { "UserId" });
            DropIndex("Identity.AspNetRoles", "RoleNameIndex");
            DropIndex("ProjectDocuments.ProjectDocumentValue", new[] { "ProjectId" });
            DropIndex("ProjectDocuments.ProjectDocumentValue", new[] { "ProjectDocumentId" });
            DropIndex("ProjectDocuments.ProjectDocumentFileDeleted", new[] { "ProjectId" });
            DropIndex("ProjectDocuments.ProjectDocumentFileDeleted", new[] { "ProjectDocumentId" });
            DropIndex("Projects.Project", new[] { "Name" });
            DropIndex("ProjectDocuments.ProjectDocumentFile", new[] { "ProjectId" });
            DropIndex("ProjectDocuments.ProjectDocumentFile", new[] { "ProjectDocumentId" });
            DropTable("Identity.AspNetUserLogins");
            DropTable("Identity.AspNetUserClaims");
            DropTable("Identity.AspNetUsers");
            DropTable("Identity.AspNetUserRoles");
            DropTable("Identity.AspNetRoles");
            DropTable("ProjectDocuments.ProjectDocumentValue");
            DropTable("ProjectDocuments.ProjectDocumentFileDeleted");
            DropTable("ProjectDocuments.ProjectDocument");
            DropTable("Projects.Project");
            DropTable("ProjectDocuments.ProjectDocumentFile");
            DropTable("Management.Log");
        }
    }
}

namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tasks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        nom = c.String(),
                        deadline = c.DateTime(nullable: false),
                        idOrganizer = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GeneralUsers", t => t.idOrganizer)
                .Index(t => t.idOrganizer);
            
            CreateTable(
                "dbo.GeneralUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(),
                        prenom = c.String(),
                        cin = c.Int(nullable: false),
                        birthDate = c.DateTime(nullable: false),
                        address = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        cv = c.String(),
                        isOrganazer = c.Int(),
                        isSpeaker = c.Int(),
                        isUser = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        GeneralUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GeneralUsers", t => t.GeneralUser_Id)
                .Index(t => t.GeneralUser_Id);
            
            CreateTable(
                "dbo.CustomUserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Int(nullable: false),
                        GeneralUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GeneralUsers", t => t.GeneralUser_Id)
                .Index(t => t.GeneralUser_Id);
            
            CreateTable(
                "dbo.CustomUserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        GeneralUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GeneralUsers", t => t.GeneralUser_Id)
                .Index(t => t.GeneralUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomUserRoles", "GeneralUser_Id", "dbo.GeneralUsers");
            DropForeignKey("dbo.CustomUserLogins", "GeneralUser_Id", "dbo.GeneralUsers");
            DropForeignKey("dbo.CustomUserClaims", "GeneralUser_Id", "dbo.GeneralUsers");
            DropForeignKey("dbo.tasks", "idOrganizer", "dbo.GeneralUsers");
            DropIndex("dbo.CustomUserRoles", new[] { "GeneralUser_Id" });
            DropIndex("dbo.CustomUserLogins", new[] { "GeneralUser_Id" });
            DropIndex("dbo.CustomUserClaims", new[] { "GeneralUser_Id" });
            DropIndex("dbo.tasks", new[] { "idOrganizer" });
            DropTable("dbo.CustomUserRoles");
            DropTable("dbo.CustomUserLogins");
            DropTable("dbo.CustomUserClaims");
            DropTable("dbo.GeneralUsers");
            DropTable("dbo.tasks");
        }
    }
}

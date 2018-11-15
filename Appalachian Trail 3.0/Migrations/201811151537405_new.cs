namespace Appalachian_Trail_3._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Distances",
                c => new
                    {
                        DistanceID = c.String(nullable: false, maxLength: 128),
                        UserID = c.Int(nullable: false),
                        ShelterID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        DaysOnTrail = c.Int(nullable: false),
                        DailyMiles = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageDailyMiles = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DistanceLeft = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalTripMilage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DistanceID)
                .ForeignKey("dbo.ShelterInformations", t => t.ShelterID, cascadeDelete: true)
                .ForeignKey("dbo.UserInformations", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ShelterID);
            
            CreateTable(
                "dbo.ShelterInformations",
                c => new
                    {
                        ShelterID = c.Int(nullable: false, identity: true),
                        ShelterName = c.String(),
                        DistanceFromMTSpringer = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DistanceFromMTKatahdin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Elevation = c.Int(nullable: false),
                        County = c.String(),
                        State = c.String(),
                        Waypoint = c.String(),
                        UserInformation_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ShelterID)
                .ForeignKey("dbo.UserInformations", t => t.UserInformation_UserID)
                .Index(t => t.UserInformation_UserID);
            
            CreateTable(
                "dbo.UserInformations",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Gender = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
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
                        UserInformation_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInformations", t => t.UserInformation_UserID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.UserInformation_UserID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserInformation_UserID", "dbo.UserInformations");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Distances", "UserID", "dbo.UserInformations");
            DropForeignKey("dbo.ShelterInformations", "UserInformation_UserID", "dbo.UserInformations");
            DropForeignKey("dbo.Distances", "ShelterID", "dbo.ShelterInformations");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "UserInformation_UserID" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ShelterInformations", new[] { "UserInformation_UserID" });
            DropIndex("dbo.Distances", new[] { "ShelterID" });
            DropIndex("dbo.Distances", new[] { "UserID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UserInformations");
            DropTable("dbo.ShelterInformations");
            DropTable("dbo.Distances");
        }
    }
}

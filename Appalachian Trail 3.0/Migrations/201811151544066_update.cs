namespace Appalachian_Trail_3._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ShelterInformations", newName: "Shelters");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Shelters", newName: "ShelterInformations");
        }
    }
}

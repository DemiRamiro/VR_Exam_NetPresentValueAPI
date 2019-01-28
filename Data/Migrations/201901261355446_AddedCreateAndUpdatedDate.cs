namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCreateAndUpdatedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NetPresentValues", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.NetPresentValues", "LastModified", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NetPresentValues", "LastModified");
            DropColumn("dbo.NetPresentValues", "Created");
        }
    }
}

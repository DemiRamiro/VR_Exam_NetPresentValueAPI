namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCashFlows : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CashFlows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CashFlowValue = c.Double(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastModified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NetPresentValue_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NetPresentValues", t => t.NetPresentValue_Id)
                .Index(t => t.NetPresentValue_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CashFlows", "NetPresentValue_Id", "dbo.NetPresentValues");
            DropIndex("dbo.CashFlows", new[] { "NetPresentValue_Id" });
            DropTable("dbo.CashFlows");
        }
    }
}

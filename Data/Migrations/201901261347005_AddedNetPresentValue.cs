namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNetPresentValue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NetPresentValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CashInflow = c.Double(nullable: false),
                        CashOutflow = c.Double(nullable: false),
                        LowerBoundDiscountRate = c.Double(nullable: false),
                        UpperBoundDiscountRate = c.Double(nullable: false),
                        DiscountRateIncrement = c.Double(nullable: false),
                        TimePeriod = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NetPresentValues");
        }
    }
}

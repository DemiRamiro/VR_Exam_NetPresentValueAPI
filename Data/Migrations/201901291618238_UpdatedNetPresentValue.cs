namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedNetPresentValue : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NetPresentValues", "CashInflow");
            DropColumn("dbo.NetPresentValues", "CashOutflow");
            DropColumn("dbo.NetPresentValues", "TimePeriod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NetPresentValues", "TimePeriod", c => c.Int(nullable: false));
            AddColumn("dbo.NetPresentValues", "CashOutflow", c => c.Double(nullable: false));
            AddColumn("dbo.NetPresentValues", "CashInflow", c => c.Double(nullable: false));
        }
    }
}

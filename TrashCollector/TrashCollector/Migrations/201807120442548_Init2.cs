namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceDays", "BeginDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ServiceDays", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceDays", "EndDate");
            DropColumn("dbo.ServiceDays", "BeginDate");
        }
    }
}

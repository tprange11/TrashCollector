namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ServiceDays", "BeginDate", c => c.DateTime());
            AlterColumn("dbo.ServiceDays", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceDays", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ServiceDays", "BeginDate", c => c.DateTime(nullable: false));
        }
    }
}

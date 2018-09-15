namespace MGDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SamplePrep_ResearchNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SamplePrepRecords", "ResearchNumber", c => c.String(maxLength: 8));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SamplePrepRecords", "ResearchNumber");
        }
    }
}

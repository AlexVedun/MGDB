namespace MGDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChemistryRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(maxLength: 8),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        Steel = c.String(),
                        ListOfElements = c.String(),
                        ListOfEngineersId = c.Int(nullable: false),
                        CustomersListId = c.Int(nullable: false),
                        MVZListId = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                        Engineer_Id = c.Int(),
                        MVZ_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Engineers", t => t.Engineer_Id)
                .ForeignKey("dbo.MVZs", t => t.MVZ_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Engineer_Id)
                .Index(t => t.MVZ_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MVZs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Engineers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResearchDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SampleMarks = c.String(),
                        Steel = c.String(),
                        Melt = c.String(),
                        MNLZ = c.Byte(),
                        Slab = c.Short(),
                        Part = c.String(),
                        Plate = c.Short(),
                        Thickness = c.Single(),
                        TypeOfTest = c.String(),
                        Requirements = c.String(),
                        ResultsOfTest = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Researches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(maxLength: 8),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        NumberOfSamples = c.Short(nullable: false),
                        Notation = c.String(maxLength: 512),
                        Status = c.Int(nullable: false),
                        StatusDescription = c.String(maxLength: 512),
                        ResearchResults = c.String(),
                        TypeOfDefect = c.Int(),
                        FinishDate = c.DateTime(),
                        Document1 = c.Binary(),
                        Document2 = c.Binary(),
                        Document3 = c.Binary(),
                        ListOfEngineersId = c.Int(nullable: false),
                        MVZListId = c.Int(nullable: false),
                        CustomersListId = c.Int(nullable: false),
                        TypeOfResearchId = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                        Engineer_Id = c.Int(),
                        MVZ_Id = c.Int(),
                        ResearchData_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Engineers", t => t.Engineer_Id)
                .ForeignKey("dbo.MVZs", t => t.MVZ_Id)
                .ForeignKey("dbo.ResearchDatas", t => t.ResearchData_Id)
                .ForeignKey("dbo.TypeOfResearches", t => t.TypeOfResearchId, cascadeDelete: true)
                .Index(t => t.TypeOfResearchId)
                .Index(t => t.Customer_Id)
                .Index(t => t.Engineer_Id)
                .Index(t => t.MVZ_Id)
                .Index(t => t.ResearchData_Id);
            
            CreateTable(
                "dbo.TypeOfResearches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SampleMakingRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(maxLength: 8),
                        Date = c.DateTime(nullable: false),
                        Task = c.String(maxLength: 50),
                        ListOfEngineersId = c.Int(nullable: false),
                        CustomersListId = c.Int(nullable: false),
                        MVZListId = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                        Engineer_Id = c.Int(),
                        MVZ_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Engineers", t => t.Engineer_Id)
                .ForeignKey("dbo.MVZs", t => t.MVZ_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Engineer_Id)
                .Index(t => t.MVZ_Id);
            
            CreateTable(
                "dbo.SamplePrepRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(maxLength: 8),
                        Date = c.DateTime(nullable: false),
                        Task = c.String(),
                        ListOfEngineersId = c.Int(nullable: false),
                        CustomersListId = c.Int(nullable: false),
                        MVZListId = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                        Engineer_Id = c.Int(),
                        MVZ_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Engineers", t => t.Engineer_Id)
                .ForeignKey("dbo.MVZs", t => t.MVZ_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Engineer_Id)
                .Index(t => t.MVZ_Id);
            
            CreateTable(
                "dbo.MVZCustomers",
                c => new
                    {
                        MVZ_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MVZ_Id, t.Customer_Id })
                .ForeignKey("dbo.MVZs", t => t.MVZ_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.MVZ_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SamplePrepRecords", "MVZ_Id", "dbo.MVZs");
            DropForeignKey("dbo.SamplePrepRecords", "Engineer_Id", "dbo.Engineers");
            DropForeignKey("dbo.SamplePrepRecords", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.SampleMakingRecords", "MVZ_Id", "dbo.MVZs");
            DropForeignKey("dbo.SampleMakingRecords", "Engineer_Id", "dbo.Engineers");
            DropForeignKey("dbo.SampleMakingRecords", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Researches", "TypeOfResearchId", "dbo.TypeOfResearches");
            DropForeignKey("dbo.Researches", "ResearchData_Id", "dbo.ResearchDatas");
            DropForeignKey("dbo.Researches", "MVZ_Id", "dbo.MVZs");
            DropForeignKey("dbo.Researches", "Engineer_Id", "dbo.Engineers");
            DropForeignKey("dbo.Researches", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.ChemistryRecords", "MVZ_Id", "dbo.MVZs");
            DropForeignKey("dbo.ChemistryRecords", "Engineer_Id", "dbo.Engineers");
            DropForeignKey("dbo.ChemistryRecords", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.MVZCustomers", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.MVZCustomers", "MVZ_Id", "dbo.MVZs");
            DropIndex("dbo.MVZCustomers", new[] { "Customer_Id" });
            DropIndex("dbo.MVZCustomers", new[] { "MVZ_Id" });
            DropIndex("dbo.SamplePrepRecords", new[] { "MVZ_Id" });
            DropIndex("dbo.SamplePrepRecords", new[] { "Engineer_Id" });
            DropIndex("dbo.SamplePrepRecords", new[] { "Customer_Id" });
            DropIndex("dbo.SampleMakingRecords", new[] { "MVZ_Id" });
            DropIndex("dbo.SampleMakingRecords", new[] { "Engineer_Id" });
            DropIndex("dbo.SampleMakingRecords", new[] { "Customer_Id" });
            DropIndex("dbo.Researches", new[] { "ResearchData_Id" });
            DropIndex("dbo.Researches", new[] { "MVZ_Id" });
            DropIndex("dbo.Researches", new[] { "Engineer_Id" });
            DropIndex("dbo.Researches", new[] { "Customer_Id" });
            DropIndex("dbo.Researches", new[] { "TypeOfResearchId" });
            DropIndex("dbo.ChemistryRecords", new[] { "MVZ_Id" });
            DropIndex("dbo.ChemistryRecords", new[] { "Engineer_Id" });
            DropIndex("dbo.ChemistryRecords", new[] { "Customer_Id" });
            DropTable("dbo.MVZCustomers");
            DropTable("dbo.SamplePrepRecords");
            DropTable("dbo.SampleMakingRecords");
            DropTable("dbo.TypeOfResearches");
            DropTable("dbo.Researches");
            DropTable("dbo.ResearchDatas");
            DropTable("dbo.Engineers");
            DropTable("dbo.MVZs");
            DropTable("dbo.Customers");
            DropTable("dbo.ChemistryRecords");
        }
    }
}

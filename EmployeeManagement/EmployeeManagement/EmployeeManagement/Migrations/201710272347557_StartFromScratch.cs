namespace EmployeeManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartFromScratch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 16),
                        LastName = c.String(maxLength: 16),
                        Phone = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignments", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Assignments", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeViewModels");
            DropTable("dbo.Employees");
            DropTable("dbo.Assignments");
        }
    }
}

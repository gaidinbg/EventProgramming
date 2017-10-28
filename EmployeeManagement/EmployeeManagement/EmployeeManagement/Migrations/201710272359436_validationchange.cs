namespace EmployeeManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false));
        }
    }
}

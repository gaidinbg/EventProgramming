namespace EmployeeManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeViewModels", "FirstName", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.EmployeeViewModels", "LastName", c => c.String(nullable: false, maxLength: 16));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeViewModels", "LastName", c => c.String(maxLength: 16));
            AlterColumn("dbo.EmployeeViewModels", "FirstName", c => c.String(maxLength: 16));
        }
    }
}

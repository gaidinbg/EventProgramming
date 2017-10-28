using EmployeeManagement.Entities;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;



namespace EmployeeManagement.Data_Access
{
    public class EmployeesManagementDBContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Assignment> Assignments { get; set; }


        public System.Data.Entity.DbSet<EmployeeManagement.Models.EmployeeViewModel> EmployeeViewModels { get; set; }

     

        //Code First syzdavane na baza
        // Enable-Migrations -EnableAutomaticMigrations  - s tozi kod  
        //v Package Manager Console (1-vata chast) aktivirame migraciite kym bazata, 
        //s vtorata mu aktivirame awtomatichnite migracii koito da
        //da se apply-vat pri promeni
        //Update-Datagbe - chete  migraciite i gi apply-va vyrhu bazata. Ako nqma takava -  q syzdava


        //constructor - short key ctor - double tab



    }
}
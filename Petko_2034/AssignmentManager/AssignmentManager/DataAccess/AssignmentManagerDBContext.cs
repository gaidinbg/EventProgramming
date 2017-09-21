using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AssignmentManager.Entities;

namespace AssignmentManager.DataAccess
{
    public class AssignmentManagerDBContext : DbContext
    {

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Comment> Comments { get; set; }


        //Code First syzdavane na baza
        // Enable-Migrations -EnableAutomaticMigrations  - s tozi kod  v Package Manager Console (1-vata chast) aktivirame migraciite kym bazata, a s vtorata mu aktivirame awtomatichnite migracii koito da
        //da se apply-vat pri promeni
        //Update-Datagbe - chete  migraciite i gi apply-va vyrhu bazata. Ako nqma takava -  q syzdava


        //constructor - short key ctor - double tab
        public AssignmentManagerDBContext()
            : base("AssignmentManagerDb")
        // obryshtame se kym osnovniq/bazoviq konstruktor
        {

        }

    }
}
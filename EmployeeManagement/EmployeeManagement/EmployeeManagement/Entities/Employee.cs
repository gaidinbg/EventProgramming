using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Entities
{
    public class Employee : BaseEntity
    {

      
        public string FirstName { get; set; }

        public string LastName;

        public string Phone;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public  virtual List<Assignment> Assignments { get; set; }
    }
}
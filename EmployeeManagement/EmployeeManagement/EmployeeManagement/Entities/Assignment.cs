using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagement.Entities
{
    public class Assignment:BaseEntity
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public int EmployeeId { get; set; }

        public DateTime Deadline { get; set; }

        public virtual Employee Employee { get; set; }
    }
}

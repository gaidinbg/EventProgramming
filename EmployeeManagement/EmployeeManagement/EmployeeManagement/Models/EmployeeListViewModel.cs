using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class EmployeeListViewModel
    {

        public string Names { get; set; }

        public List<EmployeeViewModel> Employees { get; set; }

        public EmployeeListViewModel()
        {
            Employees = new List<EmployeeViewModel>();
        }
    }
}
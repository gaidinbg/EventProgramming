using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class EmployeeViewModel
    {

        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Minimum length is 3 symbols")]
        [MaxLength(16)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Minimum length is 3 symbols")]
        [MaxLength(16)]
        [DisplayName("Last Name")]

        public string LastName { get; set; }

        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
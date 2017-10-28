using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class AssignmentViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Title can't be empty")]
        [MinLength(3, ErrorMessage = "Minimum length is 3 symbols")]
        [MaxLength(16)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description can't be empty")]
        [MinLength(3, ErrorMessage = "Minimum length is 3 symbols")]
        [MaxLength(16)]
        [DisplayName("Description")]
        public string Description { get; set; }

         [Required(ErrorMessage = "Please choose employee")]
        public int EmployeeId { get; set; } 


         [Required(ErrorMessage = "Please set deadline")]

         public DateTime Deadline { get; set; }

    }
}
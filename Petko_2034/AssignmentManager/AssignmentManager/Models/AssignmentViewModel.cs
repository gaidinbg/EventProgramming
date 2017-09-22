using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentManager.Models
{
    public class AssignmentViewModel
    {

        public int Id { get; set; }
        [Required]
        [MinLength(8, ErrorMessage= "Kalyf, slozhi oshte nqkoi drug simvol!" )]
        [MaxLength(16)]
        [DisplayName("Zaglavie:")]
        public string Title { get; set; }
         
        [DisplayName("Opisanie:")]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool isDone { get; set; }

    }
}
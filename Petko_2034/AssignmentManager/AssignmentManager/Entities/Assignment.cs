using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentManager.Entities
{
    public class Assignment : BaseEntity
    {
        [Required]
        [MinLength(5)]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isDone { get; set; }
        public virtual List<Comment> Comments { get; set; } //vryzka kym komentartite

    // constructor

    //public Assignment
    //{


    //}

    }
}
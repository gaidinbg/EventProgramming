using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManager.Entities
{
    public class Assignment : BaseEntity
    {

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
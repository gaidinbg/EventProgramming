using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentManager.Entities
{
    public abstract class BaseEntity
        //abstract - kazva che ot tozi class/tip ne mozhe da se syzdade obekt
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
    }
}
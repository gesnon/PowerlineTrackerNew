using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerlineTrackerNew.Models
{
    public class InternalNote
    {
        public int Number { get; set; }

        public DateTime Date { get; set; }

        public string Theme { get; set; }
        
        public string Department { get; set; }

        public int PowerlineID { get; set; }

        public int ID { get; set; }

    }
}
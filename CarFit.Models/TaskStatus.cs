using System;
using System.Collections.Generic;
using System.Text;

namespace CarFit.Models
{
    public class TaskStatus
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Color { get; set; }

        /*
        1 = To Do = #4E77D6
        2 = InProgress = #F5C7O9
        3 = Done = #25A87B
        4= Rejected = #BEF6565
         */
    }
}

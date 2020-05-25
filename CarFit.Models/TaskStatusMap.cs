using System;
using System.Collections.Generic;
using System.Text;

namespace CarFit.Models
{
    public class TaskStatusMap
    {
        public TaskStatusMap()
        {
            TaskStatus = new TaskStatus();
            TaskStatusMapCollection = new List<TaskStatus>();
        }

        public TaskStatus TaskStatus { get; set; }

        public List<TaskStatus> TaskStatusMapCollection { get; set; }

    }
}

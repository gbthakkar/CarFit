using System;
using System.Collections.Generic;
using System.Text;
using CarFit.Models;

namespace CarFit.Services
{
    interface ICommonService
    {
        List<TaskStatus> GetTaskStatusList();
    }
}

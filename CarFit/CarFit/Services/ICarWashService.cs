using System;
using System.Collections.Generic;
using System.Text;
using CarFit.Models;

namespace CarFit.Services
{
    public interface ICarWashService
    {
        List<CarWashTask> GetCleaningList(DateTime fromDate);
    }
}

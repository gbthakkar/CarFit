using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarFit.Models;

namespace CarFit.WebApp.Controllers
{
    public class ApiV01Controller : Controller
    {
        // GET: ApiV01
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCleaningList()
        {
            List<CarFit.Models.CarWashTask> source = new List<CarWashTask>();

            source.Add(new CarWashTask()
            {
                HouseOwnerFirstName = "Jeff Peterson",
                WashType = "Wash medium, Clean inside",
                TaskStatus = new TaskStatus() { Name = "Done", Color = "#25A87B" },
                StartTimeUtc = new DateTime(2020, 05, 21, 8, 0, 0)
            });
            source.Add(new CarWashTask()
            {
                HouseOwnerFirstName = "Person - 2",
                WashType = "Wash medium, Wash inside",
                TaskStatus = new TaskStatus() { Name = "InProgress", Color = "#F5C7O9" },
                ExpectedStartTimeUtc = new DateTime(2020, 05, 21, 8, 0, 0),
                ExpectedEndTimeUtc = new DateTime(2020, 05, 21, 10, 0, 0)
            });
            source.Add(new CarWashTask()
            {
                HouseOwnerFirstName = "Person - 3",
                WashType = "Wash Type - 3",
                TaskStatus = new TaskStatus() { Name = "ToDo", Color = "#4E77D6" },
                StartTimeUtc = new DateTime(2020, 05, 21, 10, 0, 0)
            });
            source.Add(new CarWashTask()
            {
                HouseOwnerFirstName = "Person - 4",
                WashType = "Wash Type - 4",
                TaskStatus = new TaskStatus() { Name = "ToDo", Color = "#4E77D6" },
                StartTimeUtc = new DateTime(2020, 05, 21, 12, 0, 0)
            });
            source.Add(new CarWashTask()
            {
                HouseOwnerFirstName = "Person - 5",
                WashType = "Wash Type - 5",
                TaskStatus = new TaskStatus() { Name = "ToDo", Color = "#4E77D6" },
                StartTimeUtc = new DateTime(2020, 05, 21, 14, 0, 0)
            });

            return Json(source, JsonRequestBehavior.AllowGet);
            //return Content(JsonConvert.SerializeObject(source));

        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarFit.Models;
using CarFit.SharedLib;

namespace CarFit.WebApp.Controllers
{
    public class ApiV01Controller : Controller
    {
        // GET: ApiV01
       

        public ActionResult GetCleaningList(DateTime fromDate)
        {
            List<TaskStatus> statusList = getTaskStateList();


            List<CarFit.Models.CarWashTask> source = new List<CarWashTask>();

            source.Add(new CarWashTask()
            {
                Id=1,
                HouseOwnerFirstName = "Jeff Peterson",
                WashType = "Wash medium, Clean inside",
                TaskStatusId = TaskStatusEnum.Done.ToInt(),
                TaskStatus = statusList.FirstOrDefault(o =>o.Id == TaskStatusEnum.Done.ToInt()),
                StartTimeUtc = new DateTime(2020, 05, 21, 8, 0, 0),
                HouseOwnerLatitude = 55.778830,
                HouseOwnerLongitude = 12.521240
            });
            source.Add(new CarWashTask()
            {
                Id=2,
                HouseOwnerFirstName = "Person - 2",
                WashType = "Wash medium, Wash inside",
                TaskStatusId = TaskStatusEnum.InProgress.ToInt(),
                TaskStatus = statusList.FirstOrDefault(o=>o.Id == TaskStatusEnum.InProgress.ToInt()),
                StartTimeUtc = new DateTime(2020, 05, 21, 8, 0, 0),
                ExpectedStartTimeUtc = new DateTime(2020, 05, 21, 8, 0, 0),
                ExpectedEndTimeUtc = new DateTime(2020, 05, 21, 10, 0, 0),
                HouseOwnerLatitude = 55.774530,
                HouseOwnerLongitude = 12.519670
            });
            source.Add(new CarWashTask()
            {
                Id=3,
                HouseOwnerFirstName = "Person - 3",
                WashType = "Wash Type - 3",
                TaskStatusId = TaskStatusEnum.ToDo.ToInt(),
                TaskStatus = statusList.FirstOrDefault(o => o.Id == TaskStatusEnum.ToDo.ToInt()),
                StartTimeUtc = new DateTime(2020, 05, 21, 10, 0, 0),
                HouseOwnerLatitude = 55.786500,
                HouseOwnerLongitude = 12.512700
            });
            
            
            source.Add(new CarWashTask()
            {
                Id=4,
                HouseOwnerFirstName = "Person - 4",
                WashType = "Wash Type - 4",
                TaskStatusId = TaskStatusEnum.ToDo.ToInt(),
                TaskStatus = statusList.FirstOrDefault(o => o.Id == TaskStatusEnum.ToDo.ToInt()),
                StartTimeUtc = new DateTime(2020, 05, 22, 12, 0, 0),
                HouseOwnerLatitude = 55.778830,
                HouseOwnerLongitude = 12.521240
            });
            source.Add(new CarWashTask()
            {
                Id=5,
                HouseOwnerFirstName = "Person - 5",
                WashType = "Wash Type - 5",
                TaskStatusId = TaskStatusEnum.ToDo.ToInt(),
                TaskStatus = statusList.FirstOrDefault(o => o.Id == TaskStatusEnum.ToDo.ToInt()),
                StartTimeUtc = new DateTime(2020, 05, 22, 14, 0, 0),
                HouseOwnerLatitude = 55.774530,
                HouseOwnerLongitude = 12.519670
            });

            source.Add(new CarWashTask()
            {
                Id=6,
                HouseOwnerFirstName = "Person - 6",
                WashType = "Wash Type - 4",
                TaskStatusId = TaskStatusEnum.ToDo.ToInt(),
                TaskStatus = statusList.FirstOrDefault(o => o.Id == TaskStatusEnum.ToDo.ToInt()),
                StartTimeUtc = new DateTime(2020, 05, 23, 12, 0, 0),
                HouseOwnerLatitude = 55.776500,
                HouseOwnerLongitude = 12.512700
            });
            source.Add(new CarWashTask()
            {
                Id=7,
                HouseOwnerFirstName = "Person - 7",
                WashType = "Wash Type - 5",
                TaskStatusId = TaskStatusEnum.ToDo.ToInt(),
                TaskStatus = statusList.FirstOrDefault(o => o.Id == TaskStatusEnum.ToDo.ToInt()),
                StartTimeUtc = new DateTime(2020, 05, 23, 14, 0, 0),
                HouseOwnerLatitude = 55.778830,
                HouseOwnerLongitude = 12.521240
            });


            List<CarFit.Models.CarWashTask> filterList =
                source.Where(o => o.StartTimeUtc.Date == fromDate).OrderBy(o=>o.StartTimeUtc).ToList();

            double sLatitude = 0;
            double sLongitude = 0;
            if (filterList.Count > 1)
            {
                var ct = filterList.First();
                sLatitude = ct.HouseOwnerLatitude;
                sLongitude = ct.HouseOwnerLongitude;

                for (int i = 1; i < filterList.Count; i++)
                {
                    try
                    {
                        var nextVisit = filterList[i];
                        var sCoord = new GeoCoordinate(sLatitude, sLongitude);
                        var eCoord = new GeoCoordinate(nextVisit.HouseOwnerLatitude, nextVisit.HouseOwnerLongitude);

                        nextVisit.Distance = sCoord.GetDistanceTo(eCoord) / 1000; //Meters / 1000 = km

                        sLatitude = nextVisit.HouseOwnerLatitude;
                        sLongitude = nextVisit.HouseOwnerLongitude;

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }


            //return Json(source, JsonRequestBehavior.AllowGet);
            return Json(filterList, JsonRequestBehavior.AllowGet);
            //return Content(JsonConvert.SerializeObject(source));

        }



        private List<TaskStatus> getTaskStateList()
        {
            List<TaskStatus> lst = new List<TaskStatus>();
            lst.Add(new TaskStatus(){Id=1,Name = "ToDo",Color = "#4E77D6" });
            lst.Add(new TaskStatus() { Id = 2, Name = "InProgress", Color = "#F5C7O9" });
            lst.Add(new TaskStatus() { Id = 3, Name = "Done", Color = "#25A87B" });
            lst.Add(new TaskStatus() { Id = 4, Name = "Rejected", Color = "#BEF6565" });

            return lst;
        }

        public ActionResult GetTaskStatusList()
        {
            return Json(getTaskStateList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTaskMapList()
        {
            List<TaskStatusMap> statusMapCollection = new List<TaskStatusMap>();
            List<TaskStatus> allStatuses = getTaskStateList();

            TaskStatusMap tm = new TaskStatusMap( );
            tm.TaskStatus = allStatuses.Find(o => o.Id == TaskStatusEnum.ToDo.ToInt());
            tm.TaskStatusMapCollection.Add(allStatuses.FirstOrDefault(o => o.Id == TaskStatusEnum.InProgress.ToInt()));
            tm.TaskStatusMapCollection.Add(allStatuses.FirstOrDefault(o => o.Id == TaskStatusEnum.Rejected.ToInt()));
            statusMapCollection.Add(tm);

            tm = new TaskStatusMap();
            tm.TaskStatus = allStatuses.Find(o => o.Id == TaskStatusEnum.InProgress.ToInt());
            tm.TaskStatusMapCollection.Add(allStatuses.FirstOrDefault(o => o.Id == TaskStatusEnum.Done.ToInt()));
            tm.TaskStatusMapCollection.Add(allStatuses.FirstOrDefault(o => o.Id == TaskStatusEnum.Rejected.ToInt()));
            statusMapCollection.Add(tm);

            tm = new TaskStatusMap();
            tm.TaskStatus = allStatuses.Find(o => o.Id == TaskStatusEnum.Done.ToInt());
            statusMapCollection.Add(tm);

            tm = new TaskStatusMap();
            tm.TaskStatus = allStatuses.Find(o => o.Id == TaskStatusEnum.Rejected.ToInt());
            statusMapCollection.Add(tm);


            return Json(statusMapCollection, JsonRequestBehavior.AllowGet);
        }


    }
}
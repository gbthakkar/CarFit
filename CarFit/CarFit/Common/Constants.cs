﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarFit.Common
{
    public class Constants
    {
        //public static string DataApiUrl = "http://10.0.2.2:44325/ApiV01";
        public static string DataApiUrl = "http://10.0.2.2:5000/ApiV01";
        //public static string DataApiUrl = "http://CarFitWebApp.NishchalSoft.com/ApiV01";
        

        public static string CleaningListUrl = $"{DataApiUrl}/GetCleaningList";
        public static string TaskStatusListUrl = $"{DataApiUrl}/GetTaskStatusList";
        public static string GetTaskMapList = $"{DataApiUrl}/GetTaskMapList";


    }
}

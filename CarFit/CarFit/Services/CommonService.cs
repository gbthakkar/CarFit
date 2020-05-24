using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using CarFit.Models;
using Newtonsoft.Json;

namespace CarFit.Services
{
    public class CommonService : ICommonService
    {
        public List<TaskStatus> GetTaskStatusList()
        {
            string listJson = "";
            byte[] resultBytes = null;

            HttpClient hc = new HttpClient();
            WebClient wc = new WebClient();

            List<TaskStatus> lst = new List<TaskStatus>();

            try
            {
                string url = $"{Common.Constants.TaskStatusListUrl}";
                //resultBytes = hc.GetByteArrayAsync(url).Result;
                //listJson = System.Text.UTF8Encoding.UTF8.GetString(resultBytes);


                resultBytes = wc.DownloadData(url);
                listJson = System.Text.Encoding.UTF8.GetString(resultBytes);

                lst = JsonConvert.DeserializeObject<List<TaskStatus>>(listJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //throw;
            }


            return lst;
        }
    }
}

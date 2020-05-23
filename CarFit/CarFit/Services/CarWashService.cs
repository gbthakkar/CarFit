using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using CarFit.Models;
using Newtonsoft.Json;

namespace CarFit.Services
{
    public class CarWashService:ICarWashService
    {
        public List<CarWashTask> GetCleaningList(DateTime fromDate)
        {
            string listJson = "";
            byte[] resultBytes = null;

            HttpClient hc = new HttpClient();
            WebClient wc = new WebClient();

            List<CarWashTask> lst = new List<CarWashTask>();

            try
            {
                string url = $"{Common.Constants.CleaningListUrl}?fromDate={fromDate:yyyy-MM-dd}" ;
                //resultBytes = hc.GetByteArrayAsync(url).Result;
                //listJson = System.Text.UTF8Encoding.UTF8.GetString(resultBytes);

                
                resultBytes = wc.DownloadData(url);
                listJson = System.Text.Encoding.UTF8.GetString(resultBytes);

                lst = JsonConvert.DeserializeObject<List<CarWashTask>>(listJson);
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

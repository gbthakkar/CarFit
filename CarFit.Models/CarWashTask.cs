using System;
using System.Collections.Generic;
using System.Text;


namespace CarFit.Models
{
    public class CarWashTask
    {

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string HouseOwnerFirstName { get; set; }
        public string HouseOwnerLastName { get; set; }
        public string FullName
        {
            get
            {
                string fname = string.IsNullOrWhiteSpace(this.HouseOwnerFirstName)
                    ? ""
                    : this.HouseOwnerFirstName.Trim();
                string lname = string.IsNullOrWhiteSpace(this.HouseOwnerLastName) ? "" : this.HouseOwnerLastName.Trim();
                return $"{fname} {lname}";


            }
        }
        public string WashType { get; set; }

        public int TaskStatusId { get; set; }
        public TaskStatus TaskStatus { get; set; }



        /// <summary>
        /// Planned Time
        /// </summary>
        public DateTime StartTimeUtc { get; set; }//when have time schedule by planner.

        /// <summary>
        /// Start time for time slot required by customer.
        /// </summary>
        public DateTime? ExpectedStartTimeUtc { get; set; }//when customer ask for specific time slot.

        /// <summary>
        /// End time for time slot required by customer.
        /// </summary>
        public DateTime? ExpectedEndTimeUtc { get; set; }//when customer ask for specific time slot.

        public string BookingTime
        {
            get
            {
                string temp = "";
                //if (this.StartTimeUtc.HasValue)
                //{
                //    temp = this.StartTimeUtc.GetValueOrDefault().ToString("hh:mm");
                //}
                //else
                //{
                //    if (this.ExpectedStartTimeUtc.HasValue)
                //    {
                //        temp = this.ExpectedStartTimeUtc.GetValueOrDefault().ToString("hh:mm");
                //    }
                //    if (this.ExpectedEndTimeUtc.HasValue)
                //    {
                //        temp = temp + " / " + this.ExpectedEndTimeUtc.GetValueOrDefault().ToString("hh:mm");
                //    }
                //}


                if (this.ExpectedStartTimeUtc.HasValue)
                {
                    temp = this.ExpectedStartTimeUtc.GetValueOrDefault().ToString("hh:mm");
                    if (this.ExpectedEndTimeUtc.HasValue)
                    {
                        temp = temp + " / " + this.ExpectedEndTimeUtc.GetValueOrDefault().ToString("hh:mm");
                    }
                }
                else
                {
                    temp = this.StartTimeUtc.ToString("hh:mm");
                }

                return temp;
            }

        }
    }
}

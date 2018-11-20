using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Appalachian_Trail_3._0.Models
{
    public class Distance
    {
        [Key]
        public string DistanceID { get; set; }

        public int UserID { get; set; }

        public int ShelterID { get; set; }

        //This is the Trail Start Date
        public System.DateTime StartDate { get; set; }

        public int DaysOnTrail { get; set; }

        public decimal DailyMiles { get; set; }

        public decimal AverageDailyMiles { get; set; }

        public decimal DistanceLeft { get; set; }

        //This is the Total Trip Milage for the hiker so far
        public decimal TotalTripMilage { get; set; }

        public virtual Shelters Shelters { get; set; }

        public virtual UserInformation UserInformation { get; set; }
    }
}
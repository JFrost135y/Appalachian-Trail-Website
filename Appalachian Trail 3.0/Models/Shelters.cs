using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Appalachian_Trail_3._0.Models
{
    public class Shelters
    {
        [Key]
        public int ShelterID { get; set; }

        //public int UserID { get; set; }

        public virtual UserInformation UserInformation { get; set; }

        public string ShelterName { get; set; }

        public decimal DistanceFromMTSpringer { get; set; }

        public decimal DistanceFromMTKatahdin { get; set; }

        public int Elevation { get; set; }

        public string County { get; set; }

        public string State { get; set; }

        public string Waypoint { get; set; }

        public virtual ICollection<Distance> Distances { get; set; }

    }
}
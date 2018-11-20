using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Appalachian_Trail_3._0.Models
{
    public class TrackerViewModel
    {
        IEnumerable<Shelters> StartingShelers { get; set; }

        IEnumerable<Shelters> EndingShelers { get; set; }

    }
}
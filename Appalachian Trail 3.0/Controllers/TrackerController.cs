using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Appalachian_Trail_3._0.Models;

namespace Appalachian_Trail_3._0.Controllers
{
    public class TrackerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Tracker
        public ActionResult Index()
        {
            var State = db.Shelters.Select(x=>x.State).Distinct().ToList();
            List<SelectListItem> States = new List<SelectListItem>();
            foreach(var item in State)
            {
                SelectListItem li = new SelectListItem { Text = item, Value = item };
                States.Add(li);
            }
            return View(States);
        }
    }
}
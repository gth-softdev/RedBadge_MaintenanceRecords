using MaintenanceRecords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadge_MaintenanceRecords.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            var model = new LocationListItem[0];
            return View(model);
        }
    }
}
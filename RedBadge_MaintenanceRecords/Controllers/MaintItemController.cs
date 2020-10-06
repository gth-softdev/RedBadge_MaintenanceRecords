using MaintenanceRecords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadge_MaintenanceRecords.Controllers
{
    [Authorize]
    public class MaintItemController : Controller
    {
        // GET: MaintItem
        public ActionResult Index()
        {
            var model = new MaintItemListItem();
            return View(model);
        }
    }
}
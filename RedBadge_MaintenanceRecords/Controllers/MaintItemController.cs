using MaintenanceRecords.Data;
using MaintenanceRecords.Models;
using MaintenanceRecords.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedBadge_MaintenanceRecords.Controllers
{
    public class MaintItemController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: MaintItem
        public ActionResult Index()
        {
            ViewBag.SiteName = new SelectList(_db.ItemLocations, "LocationId", "SiteName");
            //return View(_db.MaintItems.ToList());

            //ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "FullName");
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaintItemService(userId);
            var model = service.GetMaintItems();
            var sortedList = model.OrderBy(item => item.ItemName).ToArray();

            return View(model);
        }

        //public ActionResult show(int id)
        //{
        //    var svc = CreateMaintItemService();
        //    var model = svc.GetMaintRecordsByItem(id);

        //    return View(model);

            //return View(_db.MaintItems.ToList());

            //ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "FullName");



            //USE THIS
            //ViewBag.SiteName = new SelectList(_db.ItemLocations, "LocationId", "SiteName");
            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var service = new MaintItemService(userId);
            //var model = service.GetMaintItems();
            //var sortedList = model.OrderBy(item => item.ItemName).ToArray();

            //return View(model);
        //}

        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(_db.ItemLocations, "LocationId", "SiteName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MaintItemCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMaintItemService();

            if (service.CreateMaintItem(model))
            {
                TempData["SaveResult"] = "The item was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Item could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMaintItemService();
            var model = svc.GetMaintItemById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.LocationId = new SelectList(_db.ItemLocations, "LocationId", "SiteName");
            var service = CreateMaintItemService();
            var detail = service.GetMaintItemById(id);
            var model =
                new MaintItemEdit
                {
                    ItemId = detail.ItemId,
                    ItemName = detail.ItemName,
                    Year = detail.Year,
                    Make = detail.Make,
                    ItemModel = detail.ItemModel,
                    MiscInfo = detail.MiscInfo,
                    LocationId = detail.LocationId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MaintItemEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ItemId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMaintItemService();

            if (service.UpdateMaintItem(model))
            {
                TempData["SaveResult"] = "The item was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your item could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMaintItemService();
            var model = svc.GetMaintItemById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMaintItem(int id)
        {
            var service = CreateMaintItemService();

            service.DeleteMaintItem(id);

            TempData["SaveResult"] = "The item was deleted";

            return RedirectToAction("Index");
        }

        private MaintItemService CreateMaintItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaintItemService(userId);
            return service;
        }
    }
}
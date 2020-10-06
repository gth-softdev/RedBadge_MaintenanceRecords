using MaintenanceRecords.Data;
using MaintenanceRecords.Models;
using MaintenanceRecords.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RedBadge_MaintenanceRecords.Controllers
{
    [Authorize]
    public class MaintRecordController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: MaintRecord
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaintRecordService(userId);
            var model = service.GetMaintRecords();
            return View(model);
        }

        //Add method here VVVV
        //GET
        public ActionResult Create()
        {
            return View();
        }

        //Add code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MaintRecordCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaintRecordService(userId);

            if (service.CreateMaintRecord(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The record could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaintRecordService(userId);
            //var model = service.GetMaintRecords();
            //var model = new GetMaintRecordById(id);
            var model = service.GetMaintRecordById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaintRecordService(userId);
            var detail = service.GetMaintRecordById(id);
            var model =
                new MaintRecordEdit
                {
                    RecordId = detail.RecordId,
                    ItemId = detail.ItemId,
                    RecordText = detail.RecordText,
                    RecordDate = detail.RecordDate
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MaintRecordEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RecordId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }


            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaintRecordService(userId);
            

            if (service.UpdateMaintRecord(model))
            {
                TempData["SaveResult"] = "Your record was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your record could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaintRecordService(userId);
            //var model = service.GetMaintRecords();
            //var model = new GetMaintRecordById(id);
            var model = service.GetMaintRecordById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMaintRecord(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MaintRecordService(userId);
            //var model = service.GetMaintRecords();
            //var model = new GetMaintRecordById(id);
            //var model = service.GetMaintRecordById(id);

            service.DeleteRecord(id);

            TempData["SaveResult"] = "Your record was deleted";

            return RedirectToAction("Index");
        }
    }
}
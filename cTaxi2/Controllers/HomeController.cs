using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using cTaxi2.Init;
using cTaxi2.Models;
using cTaxi2.ViewModel;
using Convert = cTaxi2.Helper.Convert;

namespace cTaxi2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            InitData.CreateData();
            return View();
        }
        [HttpPost]
        public ActionResult Index(LogIn member)
        {
            var records = GetRecords();
            Session["user"] = "approved";
            return View("Records", records);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (IsLogined())
            {
                var driver = InitData.GetDriversByID(id);
                var vieDriver = Helper.Convert.GetDriverViewModel(driver);
                return View(vieDriver);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (IsLogined())
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(DriverViewModel driver)
        {
            if (IsLogined())
            {
                var newDriver = Helper.Convert.ToDriverModel(driver);
                InitData.AddRecors(newDriver);
            }
            return Index(null);
        }

        public ActionResult Edit(DriverViewModel driver)
        {
            if (!IsLogined())
                return RedirectToAction("Index");
            var model = Helper.Convert.ToDriverModel(driver);
            InitData.UpdateDriver(model);
            return Index(null);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (!IsLogined())
                return RedirectToAction("Index");
            InitData.DeleteByID(id);
            return Index(null);
        }

        private bool IsLogined()
        {
            if (Session["user"] != null && Session["user"] == "approved")
                return true;
            return false;
        }
        public ActionResult LogOut()
        {
            Session["user"] = null;
            return RedirectToAction("Index");
        }
        private List<DriverViewModel> GetRecords()
        {
            var drivers = InitData.GetDrivers();
            var converted = Helper.Convert.GetDriverViewListModel(drivers);
            return converted.OrderByDescending(x => x.BeginJob).ToList();

        }
    }
}
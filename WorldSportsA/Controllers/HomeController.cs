using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldSportsA.Models;

namespace WorldSportsA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ReportsRepository ReportRep = new ReportsRepository();
            var myreport = ReportRep.GetAllReports().OrderByDescending(k => k.Match.Fixture.TimeStamp).FirstOrDefault();


            return View(myreport);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
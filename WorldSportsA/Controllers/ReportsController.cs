using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldSportsA.Models;

namespace WorldSportsA.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            ReportsRepository reportrep = new ReportsRepository();
            var myreports = reportrep.GetAllReports();

            if (myreports.Count() > 0)
            {
                ViewData["MyReports"] = myreports.OrderByDescending(k => k.Match.Fixture.TimeStamp);
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Add()
        {
            List<SelectListItem> matchlist = new List<SelectListItem>();
            MatchesRepository matchrep = new MatchesRepository();
            var mymatches = matchrep.GetAllMatches().OrderByDescending(k => k.Fixture.TimeStamp);

            if (mymatches.Count() > 0)
            {
                foreach (Match m in mymatches)
                {
                    SelectListItem sli = new SelectListItem();
                    sli.Value = m.Id.ToString();
                    sli.Text = m.Fixture.HomeTeamName + " (" + m.HomeTeamGoals + " - " + m.AwayTeamGoals + ") " + m.Fixture.AwayTeamName;
                    matchlist.Add(sli);
                }
            }
            ViewData["MyReports"] = matchlist;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Add(Report report)
        {
            List<SelectListItem> matchlist = new List<SelectListItem>();
            MatchesRepository matchrep = new MatchesRepository();
            var mymatches = matchrep.GetAllMatches().OrderByDescending(k => k.Fixture.TimeStamp);

            if (mymatches.Count() > 0)
            {
                foreach (Match m in mymatches)
                {
                    SelectListItem sli = new SelectListItem();
                    sli.Value = m.Id.ToString();
                    sli.Text = m.Fixture.HomeTeamName + " (" + m.HomeTeamGoals + " - " + m.AwayTeamGoals + " ) " + m.Fixture.HomeTeamName;
                    matchlist.Add(sli);
                }
            }
            ViewData["MyReports"] = matchlist;

            if (!String.IsNullOrEmpty(report.Comment))
            {
                //Continue
                ReportsRepository ReportRep = new ReportsRepository();
                ReportRep.Add(report);
                ReportRep.SaveChanges();

                return Redirect("/reports");
            }
            else
            {
                ModelState.AddModelError("Comment,", "Please make sure you have entered a match report");
            }
            return View(report);
        }

        public ActionResult View(int Id)
        {
            ReportsRepository ReportRep = new ReportsRepository();
            var myreport = ReportRep.GetAllReports().Where(r => r.Id == Id).FirstOrDefault();

            if (myreport != null)
            {
                return View(myreport);
            }
            else
            {
                return Redirect("/");
            }
        }

        public ActionResult All()
        {
            ReportsRepository reportrep = new ReportsRepository();
            var myreports = reportrep.GetAllReports();

            if (myreports.Count() > 0)
            {
                ViewData["MyReports"] = myreports.OrderByDescending(k => k.Match.Fixture.TimeStamp).ThenByDescending(k => k.Id);
            }
            return View();
        }
    }
}
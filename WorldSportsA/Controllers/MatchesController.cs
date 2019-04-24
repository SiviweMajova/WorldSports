using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldSportsA.Models;

namespace WorldSportsA.Controllers
{
    public class MatchesController : Controller
    {
        // GET: Matches
        public ActionResult Index()
        {
            MatchesRepository matchrep = new MatchesRepository();
            var mymatches = matchrep.GetAllMatches();

            if (mymatches.Count() > 0)
            {
                ViewData["MyMatches"] = mymatches.OrderByDescending(k => k.Fixture.TimeStamp);
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Add()
        {
            List<SelectListItem> fixturelist = new List<SelectListItem>();
            FixturesRepository fixrep = new FixturesRepository();
            var myfixtures = fixrep.GetAllFixtures().OrderByDescending(k => k.TimeStamp);

            if (myfixtures.Count() > 0)
            {
                foreach (Fixture f in myfixtures)
                {
                    SelectListItem sli = new SelectListItem();
                    sli.Value = f.Id.ToString();
                    sli.Text = f.HomeTeamName + " vs " + f.AwayTeamName;
                    fixturelist.Add(sli);
                }
            }
            ViewData["MyMatches"] = fixturelist;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(Match match)
        {
            List<SelectListItem> fixturelist = new List<SelectListItem>();
            FixturesRepository fixrep = new FixturesRepository();
            var myfixtures = fixrep.GetAllFixtures().OrderByDescending(k => k.TimeStamp);

            if (myfixtures.Count() > 0)
            {
                foreach (Fixture f in myfixtures)
                {
                    SelectListItem sli = new SelectListItem();
                    sli.Value = f.Id.ToString();
                    sli.Text = f.HomeTeamName + " vs " + f.AwayTeamName;
                    fixturelist.Add(sli);
                }
            }
            ViewData["MyMatches"] = fixturelist;

            MatchesRepository matchrep = new MatchesRepository();
            if (match.HomeTeamGoals != null)
            {
                if (match.AwayTeamGoals != null)
                {
                    matchrep.Add(match);
                    matchrep.SaveChanges();

                    return Redirect("/matches");
                }
                else
                {
                    ModelState.AddModelError("TeamAwayGoals", "Please make sure you've entered the number of goals that the away team scored");
                }
            }
            else
            {
                ModelState.AddModelError("TeamHomeGoals", "Please make sure you've entered the number of goals that the home team scored");
            }
            return View(match);
        }
    }
}
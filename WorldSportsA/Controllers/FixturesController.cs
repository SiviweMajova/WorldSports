using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldSportsA.Models;

namespace WorldSportsA.Controllers
{
    public class FixturesController : Controller
    {
        // GET: Fixtures
        public ActionResult Index()
        {
            FixturesRepository FixturesRep = new FixturesRepository();
            var myfixtures = FixturesRep.GetAllFixtures();

            if (myfixtures.Count() > 0)
            {
                ViewData["MyFixtures"] = myfixtures.OrderByDescending(k => k.TimeStamp);
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Add()
        {
            List<SelectListItem> teamlist = new List<SelectListItem>();
            TeamsRepository TeamsRep = new TeamsRepository();
            var myteams = TeamsRep.GetAllTeams().OrderBy(k => k.Name);
            if (myteams.Count() > 0)
            {
                foreach (Team t in myteams)
                {
                    SelectListItem sli = new SelectListItem();
                    sli.Value = t.Id.ToString();
                    sli.Text = t.Name;
                    teamlist.Add(sli);
                }
            }

            ViewData["Teams"] = teamlist;

            List<SelectListItem> venuelist = new List<SelectListItem>();
            VenuesRepository VenuesRep = new VenuesRepository();
            var myvenues = VenuesRep.GetAllVenues().OrderBy(k => k.Name);
            if (myvenues.Count() > 0)
            {
                foreach (Venue v in myvenues)
                {
                    SelectListItem sli = new SelectListItem();
                    sli.Value = v.Id.ToString();
                    sli.Text = v.Name;
                    venuelist.Add(sli);
                }
            }

            ViewData["Venues"] = venuelist;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(Fixture fixture)
        {
            List<SelectListItem> teamlist = new List<SelectListItem>();
            TeamsRepository TeamsRep = new TeamsRepository();
            var myteams = TeamsRep.GetAllTeams().OrderBy(k => k.Name);
            if (myteams.Count() > 0)
            {
                foreach (Team t in myteams)
                {
                    SelectListItem sli = new SelectListItem();
                    sli.Value = t.Id.ToString();
                    sli.Text = t.Name;
                    teamlist.Add(sli);
                }
            }

            ViewData["Teams"] = teamlist;

            List<SelectListItem> venuelist = new List<SelectListItem>();
            VenuesRepository VenuesRep = new VenuesRepository();
            var myvenues = VenuesRep.GetAllVenues().OrderBy(k => k.Name);
            if (myvenues.Count() > 0)
            {
                foreach (Venue v in myvenues)
                {
                    SelectListItem sli = new SelectListItem();
                    sli.Value = v.Id.ToString();
                    sli.Text = v.Name;
                    venuelist.Add(sli);
                }
            }

            ViewData["Venues"] = venuelist;

            FixturesRepository FixturesRep = new FixturesRepository();
            if (fixture.TimeStamp > DateTime.Today)
            {
                if (fixture.TimeStamp != null)
                {
                    if (fixture.HomeTeamId != fixture.AwayTeamId)
                    {
                        //if (teamsrep.GetAllTeams().Where(k => k.Name.ToLower() == team.Name.ToLower()).Count() > 0)
                        if (FixturesRep.GetAllFixtures().Any(k => k.TimeStamp == fixture.TimeStamp && FixturesRep.GetAllFixtures().Any(s => s.VenueName == fixture.VenueName)))
                        {
                            ModelState.AddModelError("TimeStamp", "There is a match in this venue at this time, add valid fixture");
                            //FixturesRep.Add(fixture);
                            //FixturesRep.SaveChanges();
                            //return Redirect("/fixtures");
                        }
                        else
                        {
                            //ModelState.AddModelError("VenuedId", "There is a match at this venue at this time, add valid fixture");
                            FixturesRep.Add(fixture);
                            FixturesRep.SaveChanges();

                            return Redirect("/fixtures");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("HomeTeamId", "Please make sure that the teams are different for home and away sides");
                        ModelState.AddModelError("AwayTeamId", "Please make sure that the teams are different for home and away sides");
                    }
                }
                else
                {
                    ModelState.AddModelError("TimeStamp", "Invalid date e.g. 20 November 2019");
                }
            }
            else
            {
                ModelState.AddModelError("TimeStamp", "You can't add fixtures on the past, Enter a future date");
            }
            return View(fixture);
        }
    }
}

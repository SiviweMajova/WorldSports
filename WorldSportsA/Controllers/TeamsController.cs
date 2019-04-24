
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldSportsA.Models;
using System.Net;
using System.IO;

namespace WorldSportsA.Controllers
{
    public class TeamsController : Controller
    {
        // GET: Teams
        public ActionResult Index()
        {

            TeamsRepository TeamsRep = new TeamsRepository();
            var myteams = TeamsRep.GetAllTeams();

            if(myteams.Count()> 0)
            {
                ViewData["MyTeams"] = myteams.OrderBy(k=>k.Name);
            }

            return View();
        }

    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult Add()
    {
        List<SelectListItem> venuelist = new List<SelectListItem>();
        VenuesRepository VenuesRep = new VenuesRepository();
        var myvenues = VenuesRep.GetAllVenues().OrderByDescending(k => k.Id);
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
    public ActionResult Add(Team team)
    {
        List<SelectListItem> venuelist = new List<SelectListItem>();
        VenuesRepository VenuesRep = new VenuesRepository();
        var myvenues = VenuesRep.GetAllVenues().OrderBy(k => k.Name);
        TeamsRepository teamsrep = new TeamsRepository();

          //---  string fileName = Path.GetFileNameWithoutExtension(team.ImageUpload.FileName);
   // string extension = Path.GetExtension(team.ImageUpload.FileName);
    //fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
   // team.LogoUrl = "~/Content/images/" + fileName;
   // fileName = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
   // team.ImageUpload.SaveAs(fileName);
    
    
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

         
        if (!String.IsNullOrWhiteSpace(team.Name))
        {
       

            if (teamsrep.GetAllTeams().Where(k => k.Name.ToLower() == team.Name.ToLower()).Count() > 0)
            {
                ModelState.AddModelError("Name", "That team name is already in use");
            }
            else
            {
                teamsrep.Add(team);
                teamsrep.SaveChanges();

                return Redirect("/teams");
            }

        }
        else
        {
            //No team entered
            ModelState.AddModelError("Name", "Please enter team name");

        }
        return View(team);

    }
       

            [AcceptVerbs(HttpVerbs.Get)]
            public ActionResult Edit(int? id)
            {


                //var tm = db.Teams.Where(t => t.TeamId == id).FirstOrDefault
                TeamsRepository TeamsRep = new TeamsRepository();
                var myteams = TeamsRep.GetAllTeams().SingleOrDefault(t => t.Id == id);


                return View(myteams);
            }

            [AcceptVerbs(HttpVerbs.Post)]
            public ActionResult Edit(Team t)
            {

                TeamsRepository TeamsRep = new TeamsRepository();
                //var logo = t.Logo;
                var name = t.Name;
                var venue = t.VenueId;
                var admin = t.Administrator;
                var coach = t.Coach;

            

                //Update 


                return RedirectToAction("Index");
            }

            public ActionResult All()
            {
                TeamsRepository teamsrep = new TeamsRepository();
                var myteams = teamsrep.GetAllTeams();

                if (myteams.Count() > 0)
                {
                    ViewData["MyTeams"] = myteams.OrderBy(t => t.Name);

                }
                return View();
            }

                public ActionResult View(int Id)
                {
                        TeamsRepository TeamsRep = new TeamsRepository();
                        var allteams = TeamsRep.GetAllTeams().Where(t => t.Id != Id).OrderBy(t => t.Name);


                if (allteams.Count() > 0)
                {
                    ViewData["AllTeams"] = allteams;
                }

                var myteam = TeamsRep.GetAllTeams().Where(t => t.Id == Id).FirstOrDefault();

                if (myteam != null)
                {
                    PlayersRepository playerrep = new PlayersRepository();
                    ReportsRepository ReportRep = new ReportsRepository();
                    var allreports = ReportRep.GetAllReports().Where(r => r.Match.Fixture.HomeTeamId == Id || r.Match.Fixture.AwayTeamId == Id).OrderByDescending(r => r.Match.Fixture.TimeStamp);
                   


                if (Request.QueryString["opponent"] != null)
                {
                var opponent = allteams.Where(t => t.Id.ToString() == Request.QueryString["opponent"].ToString()).FirstOrDefault();
                if (opponent != null)
                {
                     ViewData["OpponentTeamName"] = opponent.Name;
                     allreports = allreports.Where(k => k.Match.Fixture.HomeTeamId == opponent.Id || k.Match.Fixture.AwayTeamId == opponent.Id).OrderByDescending(k => k.Match.Fixture.TimeStamp);
                ///return
                }
                }
                    
                    var allhomegames = allreports.Where(h => h.Match.Fixture.HomeTeamId == Id);
                    var allawaygames = allreports.Where(h => h.Match.Fixture.AwayTeamId == Id);

                    if (allhomegames.Count() > 0)
                    {
                        ViewData["HomeGames"] = allhomegames;
                    }

                    if (allawaygames.Count() > 0)
                    {
                        ViewData["AwayGames"] = allawaygames;
                    }
                        return View(myteam);
                    }
                    else
                    {
                        return Redirect("/");
                    }
                }
    
    }
}
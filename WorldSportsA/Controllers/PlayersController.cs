using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldSportsA.Models;


namespace WorldSportsA.Controllers
{
    public class PlayersController : Controller
    {
        // GET: Players
        CoreDataContext db = new CoreDataContext();
        PlayersRepository PlayersRep = new PlayersRepository();
        TeamsRepository TeamsRep = new TeamsRepository();

        public ActionResult Index(int? Id)
        {
            Id = Convert.ToInt32(TeamsRep.GetAllTeams().OrderBy(t => t.Id));

            var myplayers = PlayersRep.GetAllPlayers().Where(p => p.TeamId == Id);
  
            if (myplayers.Count() > 0)
            {
                ViewData["MyPlayers"] = myplayers.OrderBy(p => p.Team.Players);    
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Add()
        {
            List<SelectListItem> teamlist = new List<SelectListItem>();
            
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

            ViewData["MyTeams"] = teamlist;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(Player player)
        {
            var Id = Convert.ToInt32(TeamsRep.GetAllTeams().OrderBy(t => t.Id));
            List<SelectListItem> teamlist = new List<SelectListItem>();
        
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

            ViewData["MyTeams"] = teamlist;

            var teamplayers =  TeamsRep.GetAllTeams().Where(t => t.Id == player.TeamId);
            
            if (!String.IsNullOrEmpty(player.FirstNames))
            {
                if (PlayersRep.GetAllPlayers().Where(k => k.FirstNames.ToLower() == player.FirstNames.ToLower()).Count() > 0)
                {
                    ModelState.AddModelError("FullName", "That player already exist");
                }
                else
                {
                    PlayersRep.Add(player);
                    PlayersRep.SaveChanges();

                    return Redirect("/players/index/id");
                }
            }
            else
            {
                //No player entered
                ModelState.AddModelError("FullName", "Please enter player name");
            }
            return View(player);
        }

        public ActionResult View(int Id)
        {
            PlayersRepository PlayerRep = new PlayersRepository();
            var myplayer = PlayerRep.GetAllPlayers().Where(r => r.Id == Id).FirstOrDefault();

            if (myplayer != null)
            {
                return View(myplayer);
            }
            else
            {
                return Redirect("/");
            }
        }
    }
}
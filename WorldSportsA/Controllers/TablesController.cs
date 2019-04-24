using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldSportsA.Models;

namespace WorldSportsA.Controllers
{
    public class TablesController : Controller
    {
        // GET: Tables
        public ActionResult Index()
        {
            List<LeagueTableResults> results = new List<LeagueTableResults>();
            MatchesRepository matchesrep = new MatchesRepository();
            var allmatches = matchesrep.GetAllMatches();

            TeamsRepository teamsrep = new TeamsRepository();

            var allteams = teamsrep.GetAllTeams();

            if (allteams.Count() > 0)
            {
                foreach (Team t in allteams)
                {

                    LeagueTableResults res = new LeagueTableResults();
                    res.TeamId = t.Id;
                    res.TeamName = t.Name;

                    //Calculate number of wins

                    int wins = 0;
                    int lost = 0;
                    int draws = 0;

                    int fgoals = 0;
                    int agoals = 0;

                    int points = 0;


                    var allteammatches = allmatches.Where(m => m.Fixture.HomeTeamId == t.Id || m.Fixture.AwayTeamId == t.Id);
                    var allteamhomematches = allteammatches.Where(m => m.Fixture.HomeTeamId == t.Id);
                    var allteamawaymatches = allteammatches.Where(m => m.Fixture.AwayTeamId == t.Id);
                    var noplayed = 0;
                    noplayed = allmatches.Where(m => m.Fixture.HomeTeamId == t.Id || m.Fixture.AwayTeamId == t.Id).Count();
                    foreach (Match m in allteamhomematches)
                    {
                        if (m.HomeTeamGoals > m.AwayTeamGoals)
                        {
                            wins++;
                            points = points + 3;
                        }

                        if (m.HomeTeamGoals < m.AwayTeamGoals)
                        {
                            lost++;
                            points = points + 0;
                        }
                        if (m.HomeTeamGoals == m.AwayTeamGoals)
                        {
                            draws++;
                            points = points + 1;
                        }

                        fgoals += (int)m.HomeTeamGoals;
                        agoals += (int)m.AwayTeamGoals;
                    }

                    foreach (Match m in allteamawaymatches)
                    {
                        if (m.AwayTeamGoals > m.HomeTeamGoals)
                        {
                            wins++;
                            points = points + 3;
                        }
                        if (m.AwayTeamGoals < m.HomeTeamGoals)
                        {
                            lost++;
                            points = points + 0;
                        }
                        if (m.AwayTeamGoals == m.HomeTeamGoals)
                        {
                            draws++;
                            points = points + 1;
                        }

                        fgoals += (int)m.AwayTeamGoals;
                        agoals += (int)m.HomeTeamGoals;
                    }
                    res.Win = wins;
                    res.Lost = lost;
                    res.Draw = draws;
                    res.GF = fgoals;
                    res.GA = agoals;
                    res.GD = fgoals - agoals;
                    res.Points = points;
                    res.Played = noplayed;

                    results.Add(res);
                }
            }

            ViewData["Results"] = results.OrderByDescending(r => r.Points).ThenByDescending(r => r.GD);
            return View();
        }
    }
}
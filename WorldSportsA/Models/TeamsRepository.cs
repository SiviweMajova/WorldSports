using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldSportsA.Models
{
    public class TeamsRepository
    {
        CoreDataContext db = new CoreDataContext();

        public List<Team> GetAllTeams()
        {
            return db.Teams.ToList();
        }

        public void Add(Team t)
        {
            db.Teams.InsertOnSubmit(t);
        }

        public void SaveChanges()
        {
            db.SubmitChanges();
        }
    }
}
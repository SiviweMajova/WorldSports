using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldSportsA.Models
{
    public class PlayersRepository
    {
        CoreDataContext db = new CoreDataContext();

        public List<Player> GetAllPlayers()
        {
            return db.Players.ToList();
        }

        public void Add(Player p )
        {
            db.Players.InsertOnSubmit(p);
        }

        public void SaveChanges()
        {
            db.SubmitChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldSportsA.Models
{
    public class VenuesRepository
    {
        
        CoreDataContext db = new CoreDataContext();

        public List<Venue> GetAllVenues()
        {
            return db.Venues.ToList();
        }

        public void Add(Venue v)
        {
            db.Venues.InsertOnSubmit(v);
        }

        public void SaveChanges()
        {
            db.SubmitChanges();
        }
    }
}
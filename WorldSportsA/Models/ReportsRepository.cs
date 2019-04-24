using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldSportsA.Models
{
    public class ReportsRepository
    {
        CoreDataContext db = new CoreDataContext();

        public List<Report> GetAllReports()
        {
            return db.Reports.ToList();
        }

        public void Add(Report r)
        {
            db.Reports.InsertOnSubmit(r);
        }

        public void SaveChanges()
        {
            db.SubmitChanges();
        }
    }
}
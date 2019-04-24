using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldSportsA.Models;

namespace WorldSportsA.Controllers
{
    public class VenuesController : Controller
    {
        // GET: Venues
        public ActionResult Index()
        {
            VenuesRepository VenuesRep = new VenuesRepository();
            var myvenues = VenuesRep.GetAllVenues();

            if (myvenues.Count() > 0)
            {
                ViewData["MyVenues"] = myvenues.OrderBy(k => k.Id);

               
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Add()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(Venue venue)
        {

            if (!String.IsNullOrWhiteSpace(venue.Name))
            {
                VenuesRepository VenuesRep = new VenuesRepository();

                if (VenuesRep.GetAllVenues().Where(k => k.Name.ToLower() == venue.Name.ToLower()).Count() > 0)
                {
                    ModelState.AddModelError("Name", "Stadium with the same name has already been registered");
                }
                else
                {
                    VenuesRep.Add(venue);
                    VenuesRep.SaveChanges();

                    return Redirect("/venues");
                }

            }
            else
            {
                //No team entered
                ModelState.AddModelError("Name", "Please enter the correct name");

            }
            return View(venue);

        }
    }
}
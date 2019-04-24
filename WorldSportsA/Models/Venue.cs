using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WorldSportsA.Models
{
    public partial class Venue
    {
     
        VenuesRepository VenuesRep = new VenuesRepository();

        public string VenueName
        {
            get
            {
                return VenuesRep.GetAllVenues().Where(k => k.Id == this.Id).FirstOrDefault().Name;

            }
        }
    }
}
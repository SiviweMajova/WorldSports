using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldSportsA.Models
{
    public partial class Fixture

    {
        TeamsRepository TeamsRep = new TeamsRepository();
        VenuesRepository VenuesRep = new VenuesRepository();
        FixturesRepository FixRep = new FixturesRepository();

        public string HomeTeamName
        {
            get
            {
                return TeamsRep.GetAllTeams().Where(k => k.Id == this.HomeTeamId).FirstOrDefault().Name;

            }
        }

        public string AwayTeamName
        {
            get
            {
                return TeamsRep.GetAllTeams().Where(k => k.Id == this.AwayTeamId).FirstOrDefault().Name;

            }
        }

        public string VenueName
        {
            get
            {
                return VenuesRep.GetAllVenues().Where(k => k.Id == this.VenueId).FirstOrDefault().Name;

            }
        }
    }
}
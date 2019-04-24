using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldSportsA.Models
{
    public partial class Player
    {
        VenuesRepository VenuesRep = new VenuesRepository();
        TeamsRepository TeamsRep = new TeamsRepository();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]


        public string TeamName
        {
            get
            {
                return TeamsRep.GetAllTeams().Where(k => k.Id == this.TeamId).FirstOrDefault().Name;

            }
        }
    }
}
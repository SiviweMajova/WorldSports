using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldSportsA.Models
{
    public partial class Team
    {
        VenuesRepository VenuesRep = new VenuesRepository();
        TeamsRepository TeamsRep = new TeamsRepository();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]


        public string VenueName
        {
            get
            {
                return VenuesRep.GetAllVenues().Where(k => k.Id == this.VenueId).FirstOrDefault().Name;
                //WebImage logo = null;
//                var imagePath = "";

                //if (IsPost)
               // {
                   // logo = WebImage.GetImageFromRequest();
                   // if (logo != null)
                 //   {
                     //   newFileName = Guid.NewGuid().ToString() + "_" +
                      //      Path.GetFileName(logo.FileName);
                      //  imagePath = @"images\" + newFileName;

                      //  logo.Save(@"~\" + imagePath);
//}
               // }
            }
        }

        public string TeamName
        {
            get
            {
                return TeamsRep.GetAllTeams().Where(k => k.Id == this.Id).FirstOrDefault().Name;

            }
        }
    }
}
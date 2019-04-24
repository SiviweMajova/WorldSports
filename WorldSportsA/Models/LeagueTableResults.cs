using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldSportsA.Models
{
    public class LeagueTableResults
    {
       
            public int TeamId { get; set; }
            public string TeamName { get; set; }
            public int Played { get; set; }
            public int Win { get; set; }
            public int Draw { get; set; }
            public int Lost { get; set; }
            public int GF { get; set; }
            public int GA { get; set; }
            public int GD { get; set; }
            public int Points { get; set; }

        
    }
}
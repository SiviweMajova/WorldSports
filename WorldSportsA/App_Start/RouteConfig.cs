using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WorldSportsA
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CustomRouteForAllReports",
                url: "allreports",
                defaults: new { controller = "Reports", action = "All", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CustomRouteForAllPlayers",
                url: "allplayers",
                defaults: new { controller = "Players", action = "All", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "CustomRouteForAllTeams",
               url: "allteams",
               defaults: new { controller = "Teams", action = "All", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

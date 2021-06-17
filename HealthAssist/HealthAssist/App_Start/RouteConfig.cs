using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HealthAssist
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            Route myRoute = new Route("{controller}/{action}/{id}",
                new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" }, { "id", "1" } },
                new MvcRouteHandler());
            routes.Add(myRoute);
        }
    }
}

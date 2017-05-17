using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace emde.kz
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "HomeCustomAgreement",
                url: "UserAgreement",
                defaults: new { controller = "Home", action = "Contact" }
            );

            routes.MapRoute(
                name: "HomeAboutAgreement",
                url: "About",
                defaults: new { controller = "Home", action = "About" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Medicines", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

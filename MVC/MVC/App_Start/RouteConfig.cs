using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "MvcHome",
                url: "MvcHome",
                defaults: new { controller = "MvcHome", action = "Index", id = UrlParameter.Optional }
            );
           // routes.MapRoute(
           //    name: "SofaProduct",
           //    url: "SofasIntroduction/{controller}}/{action}/{id}",
           //    defaults: new { controller = "LivingSofasAndSleeper", action = "Index", id = UrlParameter.Optional }
           //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
    }


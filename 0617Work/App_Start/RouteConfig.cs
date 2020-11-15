using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _0617Work
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );*/

            //最初執行時
            routes.MapRoute(
                name: "/",
                url: "",
                defaults: new { Controller = "Home", Action = "Index" }
            );

            //Index
            routes.MapRoute(
                name: "Index",
                url: "Index",
                defaults: new { Controller = "Home", Action = "Index" }
            );

            //makeImage
            routes.MapRoute(
                name: "makeImage",
                url: "Index/makeImage",
                defaults: new { Controller = "Home", Action = "makeImage" }
            );

            //downloadImg
            routes.MapRoute(
                name: "downloadImg",
                url: "Index/downloadImg",
                defaults: new { Controller = "Home", Action = "downloadImg" }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DoAnLAPTRINHWEB_Nhom15
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "HomePage", action = "PageHome", id = UrlParameter.Optional },
                namespaces: new[] { "DoAnLAPTRINHWEB_Nhom15.Controllers"}
            );
        }
    }
}

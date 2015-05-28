using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using h_store.Controllers;

namespace h_store
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Web API Session Enabled Route Configurations start
            routes.MapHttpRoute(
                name: "annotationAPIStoreStatusRoute",
                routeTemplate: "app",
                defaults: new { controller = "app" }
            ).RouteHandler = new SessionStateRouteHandler();

            routes.MapHttpRoute(
                name: "annotationAPIStoreInfoRoute",
                routeTemplate: "api",
                defaults: new { controller = "annotations", action = "storeInfo", id = RouteParameter.Optional }
            ).RouteHandler = new SessionStateRouteHandler();
            
    
            routes.MapHttpRoute(
                name: "wsSocketHandler",
                routeTemplate: "ws",
                defaults: new { controller = "ws", action = "Get", id = RouteParameter.Optional }
            ).RouteHandler = new SessionStateRouteHandler();
            
            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ).RouteHandler = new SessionStateRouteHandler();
            ////Web API Session Enabled Route Configurations end here

            //MVC Routes
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }

    }
}
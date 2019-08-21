using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TalkingClock_RestService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Set default to Talking Clock
            config.Routes.MapHttpRoute(
               name: "TalkingClock",
               routeTemplate: "api/TalkingClock/",
               defaults: new { controller = "TalkingClock", action = "GetTime" }

           );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

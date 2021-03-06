﻿using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ShoppingListAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var corsAttr = new EnableCorsAttribute("http://localhost:9000", "*", "*");
            config.EnableCors(corsAttr);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}

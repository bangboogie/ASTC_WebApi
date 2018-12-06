using System.Web.Http;
using System.Web.Http.Cors;

namespace ASTC_Webservice
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //name: "ActionApi",
            //routeTemplate: "api/{controller}/{action}/{id}",    
            //defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
            name: "Createmember",
            routeTemplate: "api/{controller}/{action}",
            defaults: new { controller = "CustomersController", action = "CreateCustomerMember" }
            );

            config.Routes.MapHttpRoute(
            name: "Login",
            routeTemplate: "api/Customers/LoginCheck/{email}/{password}",
            defaults: new { controller = "Customers", action = "LoginCheck" }
            );




        }
    }
}

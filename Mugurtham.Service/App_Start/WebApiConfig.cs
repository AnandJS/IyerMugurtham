using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Mugurtham.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /*=====================================================*/
            // AUTHORIZATION MADE GLOBAL - INSTEAD CONTROLLER LEVEL
            /*====================================================*/
            config.Filters.Add(new AuthorizeAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            /*=================================================================================*/
            /*MUGURTHAM MODULE*/
            /*=================================================================================*/
            config.Routes.MapHttpRoute(
                name: "MugurthamApi",
                routeTemplate: "mugurthamapi/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            /*=================================================================================*/
            /*REGISTRATION MODULE*/
            /*=================================================================================*/
            config.Routes.MapHttpRoute(
                name: "BasicInfoAPI",
                routeTemplate: "BasicInfo/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CareerAPI",
                routeTemplate: "Career/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CotnactAPI",
                routeTemplate: "Contact/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "FamilyAPI",
               routeTemplate: "Family/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
              name: "LocationAPI",
              routeTemplate: "Location/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional }
          );

            config.Routes.MapHttpRoute(
             name: "ReferenceAPI",
             routeTemplate: "Reference/{controller}/{id}",
             defaults: new { id = RouteParameter.Optional }
         );
            /*=================================================================================*/
            /*PROFILE - WRAPPER*/
            /*=================================================================================*/
            config.Routes.MapHttpRoute(
            name: "ProfileAPI",
            routeTemplate: "FullProfile/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
            /*=================================================================================*/
            /*VIEW MODULE*/
            /*=================================================================================*/
            config.Routes.MapHttpRoute(
            name: "ProfileViewAPI",
            routeTemplate: "ProfileView/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
            /*=================================================================================*/
            /*SANGAM SUB-MODULE*/
            /*=================================================================================*/
            config.Routes.MapHttpRoute(
            name: "SangamAPI",
            routeTemplate: "Sangam/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );

            config.Routes.MapHttpRoute(
           name: "SangamAPICustom",
           routeTemplate: "SangamAPI/{controller}/{action}/{id}",
           defaults: new { id = RouteParameter.Optional }
       );

            /*=================================================================================*/
            /*ROLE SUB-MODULE*/
            /*=================================================================================*/
            config.Routes.MapHttpRoute(
            name: "RoleAPI",
            routeTemplate: "Role/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );

            /*=================================================================================*/
            /*SEARCH MODULE*/
            /*=================================================================================*/
            config.Routes.MapHttpRoute(
            name: "AllProfilesSearchAPI",
            routeTemplate: "AllProfilesSearch/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
            config.Routes.MapHttpRoute(
           name: "Search",
           routeTemplate: "SearchAPI/{controller}/{action}/{id}",
           defaults: new { id = RouteParameter.Optional }
       );

            /*=================================================================================*/
            /*USER MODULE*/
            /*=================================================================================*/
            config.Routes.MapHttpRoute(
            name: "UserAPI",
            routeTemplate: "MugurthamUser/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
            config.Routes.MapHttpRoute(
           name: "UserAPILookup",
           routeTemplate: "MugurthamUserLookup/{controller}/{action}/{id}",
           defaults: new { id = RouteParameter.Optional }
       );

            /*=================================================================================*/
            /*LOGINUSER MODULE*/
            /*=================================================================================*/
            config.Routes.MapHttpRoute(
            name: "LoginUserAPI",
            routeTemplate: "LoginUser/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
            /*=================================================================================*/
            /*LOOKUP MODULE*/
            /*=================================================================================*/
            config.Routes.MapHttpRoute(
            name: "LookupAPI",
            routeTemplate: "Lookup/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );




        }
    }
}

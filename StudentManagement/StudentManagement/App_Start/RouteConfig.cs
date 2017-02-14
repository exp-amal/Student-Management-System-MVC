using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
              name: "EditStudent",
              url: "Home/StudentsListList/EditStudent",
              defaults: new { controller = "StudentsList", action = "EditStudent", id = UrlParameter.Optional }
          );


            routes.MapRoute(
              name: "CourseList",
              url: "Home/CourseList/CourseList",
              defaults: new { controller = "CourseList", action = "CourseList", id = UrlParameter.Optional }
          );

            routes.MapRoute(
                name: "StudentsList",
                url: "Home/StudentsList/StudentsList",
                defaults: new { controller = "StudentsList", action = "StudentsList", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                 name: "CreateCourse",
                 url: "Home/CreateCourse/CreateCourse",
                 defaults: new { controller = "CreateCourse", action = "CreateCourse", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                  name: "Home",
                  url: "",
                  defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
              );

            routes.MapRoute(
                  name: "CreateStudent",
                  url: "Home/CreateStudent/CreateStudent",
                  defaults: new { controller = "CreateStudent", action = "CreateStudent", id = UrlParameter.Optional }
              );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

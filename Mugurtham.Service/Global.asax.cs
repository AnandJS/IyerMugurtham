using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Mugurtham.Service
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //This is the [Authourize] attribute set in global level for Mugurtham
            GlobalFilters.Filters.Add(new System.Web.Mvc.AuthorizeAttribute());
            //Error Handling
            //RegisterGlobalFilters(GlobalFilters.Filters);

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Common.Utilities.AsyncLogger.Error(exception.Message);
            Common.Utilities.AsyncLogger.Error(exception.StackTrace);            
            //HttpContext.Current.Response.Write(exception.StackTrace);
            Server.ClearError();
            //Response.Redirect("/Home/Error");
            Response.Clear();

            HttpException objhttpException = exception as HttpException;

            if (objhttpException != null)
            {
                string action;

                switch (objhttpException.GetHttpCode())
                {
                    case 404:
                        // page not found
                        action = "HttpError404";
                        break;
                    case 500:
                        // server error
                        action = "HttpError500";
                        break;
                    default:
                        action = "General";
                        break;
                }
                // clear error on server
                Server.ClearError();
                //Response.Redirect(String.Format("/Home/{0}/?message={1}", action, exception.Message));
                Response.Redirect(String.Format("/Home/{0}", action, exception.Message));
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            ///Mugurtham.Common.Utilities.Helpers.LogMessageInFlatFile(Mugurtham.Common.Utilities.Helpers.getLogFilePath +  "Session Start now " + DateTime.Now.ToShortDateString());
            //  Session["EhapUser"] = UserServiceManager.GetEHAPUser(HttpContext.Current.User.Identity.Name.Remove(0, 5));
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //  Session["EhapUser"] = UserServiceManager.GetEHAPUser(HttpContext.Current.User.Identity.Name.Remove(0, 5));
            //Mugurtham.Common.Utilities.Helpers.LogMessageInFlatFile(Mugurtham.Common.Utilities.Helpers.getLogFilePath +  "Session End now " + DateTime.Now.ToShortDateString());
        }


        /*public static void RegisterGlobalFilters(GlobalFilterCollection objFilters)
        {
            // Default Handler
            objFilters.Add(new HandleErrorAttribute());

            //SQL Exception Handler
            objFilters.Add(new HandleErrorAttribute
            {
                ExceptionType = typeof(SqlException),
                View = "",
                Order = 1
            }
            );


        }*/
    }
    }
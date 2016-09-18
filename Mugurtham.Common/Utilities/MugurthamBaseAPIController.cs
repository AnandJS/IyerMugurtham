using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Mugurtham.Common.Utilities
{
    public class MugurthamBaseAPIControllerAttribute : ExceptionFilterAttribute
    {
        
        public override void OnException(HttpActionExecutedContext objContext)
        {
            AsyncLogger.Error(objContext.Exception.Message);
            AsyncLogger.Error(objContext.Exception.Source);
            AsyncLogger.Error(objContext.Exception.StackTrace);

            if (objContext.Exception is NotImplementedException)
            {
                //context.Response = new  HttpResponseMessage(HttpStatusCode.NotImplemented);
                //write your custom code here            
                //objLog.Info(filterContext.Exception.Data.Values); will get the controller and action method
            }
        }

    }
}

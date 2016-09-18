using System;
using System.Web.Mvc;

namespace Mugurtham.Common.Utilities
{
    public class MugurthamBaseController : Controller, IDisposable
    {
        protected void SetAuthInfo(Guid Id, string Email, string FullName, string Role)
        {
            //AuthUtil.SetAuthInfo(Id, Email, FullName, Role);
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            //write your custom code here            
            //objLog.Info(filterContext.Exception.Data.Values); will get the controller and action method
            AsyncLogger.Error(filterContext.Exception.Message);
            AsyncLogger.Error(filterContext.Exception.InnerException.Message);
            AsyncLogger.Error(filterContext.Exception.Source);
            AsyncLogger.Error(filterContext.Exception.StackTrace);


        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            //write your custom code here
        }

             
    }
}

using System.Web.Mvc;

namespace Mugurtham.Service.Areas.MugurthamAdmin
{
    public class MugurthamAdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MugurthamAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MugurthamAdmin_default",
                "MugurthamAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

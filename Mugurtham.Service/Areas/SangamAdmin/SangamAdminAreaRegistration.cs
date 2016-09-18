using System.Web.Mvc;

namespace Mugurtham.Service.Areas.SangamAdmin
{
    public class SangamAdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SangamAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SangamAdmin_default",
                "SangamAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

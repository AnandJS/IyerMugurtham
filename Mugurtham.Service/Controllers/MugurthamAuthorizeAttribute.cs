using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Mugurtham.Core.Login;


namespace Mugurtham.Service.Controllers
{
    public class MugurthamAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        private readonly string[] arrAuthourizedRoles;
        public MugurthamAuthorizeAttribute(params string[] strArrRoles)
        {
            this.arrAuthourizedRoles = strArrRoles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            Mugurtham.Core.Login.LoggedInUser objLoggedIn = new LoggedInUser(HttpContext.Current.User.Identity.Name);
            using (objLoggedIn as IDisposable)
            {
                foreach (var strRoleID in arrAuthourizedRoles)
                {
                    if (strRoleID.ToString() == objLoggedIn.roleID)
                    {
                        authorize = true;
                    }
                    //if (strRoleID.ToString().ToLower() == strLoggedInUsersRoleID.ToLower())
                    //{
                    //    authorize = true;
                    //}
                    //var user = context.AppUser.Where(m => m.UserID == GetUser.CurrentUser/* getting user form current context */ && m.strRoleID == strRoleID &&
                    //m.IsActive == true); // checking active users with allowed strArrRoles.  
                    //if (user.Count() > 0)
                    //{
                    //    authorize = true; /* return true if Entity has current user(active) with specific strRoleID */
                    //} 
                }
                objLoggedIn.Dispose();
            }
            objLoggedIn = null;

            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}

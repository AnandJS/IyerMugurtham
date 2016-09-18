using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mugurtham.Core.User;
using Mugurtham.Core.Login;
using System.Web.Security;

namespace Mugurtham.Service.Controllers
{
    [AllowAnonymous]
    public class LoginUserAPIController : ApiController
    {
       /* [HttpPost]
        public HttpResponseMessage validateLogin([FromBody]UserCoreEntity objUserCoreEntity)
        {
            int inLoginStatus = 0;
            bool boolLogin = false;
            UserCore objUserCore = new UserCore();
            using (objUserCore as IDisposable)
            {
                inLoginStatus = objUserCore.validateLogin(ref objUserCoreEntity, out boolLogin);
            }
            objUserCore = null;
            if (inLoginStatus == 1)
            {
                FormsAuthentication.SetAuthCookie(objUserCoreEntity.LoginID, false);                
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUserCoreEntity, Configuration.Formatters.JsonFormatter);
        }*/
    }
}

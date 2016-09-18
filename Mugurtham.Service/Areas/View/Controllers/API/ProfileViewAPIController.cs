using Mugurtham.Core.Profile.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mugurtham.Common.Utilities;
using Mugurtham.Service.Controllers;

namespace Mugurtham.Service.Areas.View.Controllers.API
{
    [MugurthamBaseAPIController]
    [MugurthamAuthorizeAttribute(Mugurtham.Core.Constants.RoleIDForSangamAdmin,
                                   Mugurtham.Core.Constants.RoleIDForUserProfile,
                                   Mugurtham.Core.Constants.RoleIDForMugurthamAdmin)]
    public class ProfileViewAPIController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage getProfileByProfileID(string ID)
        {
            ProfileCore objProfileCoreForView = null;
            ProfileCore objProfileCore = new ProfileCore();
            using (objProfileCore as IDisposable)
                objProfileCore.GetByProfileID(ID, out objProfileCoreForView);
            objProfileCore = null;
            return Request.CreateResponse(HttpStatusCode.OK, objProfileCoreForView,
              Configuration.Formatters.JsonFormatter);
        }
    }
}

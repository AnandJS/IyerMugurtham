using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mugurtham.Core.BasicInfo;
using Mugurtham.Core.Profile.API;
using Mugurtham.Common.Utilities;
using Mugurtham.Service.Controllers;

namespace Mugurtham.Service.Areas.Search.Controllers.API
{
    [MugurthamBaseAPIController]
    [MugurthamAuthorizeAttribute(Mugurtham.Core.Constants.RoleIDForSangamAdmin,
                                 Mugurtham.Core.Constants.RoleIDForUserProfile,
                                 Mugurtham.Core.Constants.RoleIDForMugurthamAdmin)]
    public class AllProfilesAPIController : ApiController
    {

        public HttpResponseMessage getByProfileID(string ID)
        {
            raiseErrorForSample();
            ProfileCore objProfCore = null;
            if (!string.IsNullOrWhiteSpace(ID))
            {
                ProfileCore objProfileCore = new ProfileCore();
                using (objProfileCore as IDisposable)
                    objProfileCore.GetByProfileID(ID, out objProfCore);
                objProfileCore = null;
            }
            return Request.CreateResponse(HttpStatusCode.OK, objProfCore,
              Configuration.Formatters.JsonFormatter);
        }

        public void raiseErrorForSample()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("No product with ID = {0}", "ss")),
                ReasonPhrase = "Product ID Not Found"
            };
            int aa = 0;
            int a = (45 / aa);
            //throw new DivideByZeroException();
            //throw new NotImplementedException("This method is not implemented");
        }
    }
}

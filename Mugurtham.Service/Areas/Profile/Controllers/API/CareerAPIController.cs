using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mugurtham.Core.Career;
using Mugurtham.Common.Utilities;
using Mugurtham.Service.Controllers;

namespace Mugurtham.Service.Areas.Profile.Controllers.API
{
    [MugurthamBaseAPIController]
    [MugurthamAuthorizeAttribute(Mugurtham.Core.Constants.RoleIDForSangamAdmin,
                                 Mugurtham.Core.Constants.RoleIDForUserProfile,
                                 Mugurtham.Core.Constants.RoleIDForMugurthamAdmin)]
    public class CareerAPIController : ApiController
    {
        [HttpPost]
        public void Post([FromBody]CareerCoreEntity objCareerCoreEntity)
        {
            CareerCore objCareerCore = new CareerCore();
            using (objCareerCore as IDisposable)
            {
                objCareerCore.Add(ref objCareerCoreEntity);
            }
            objCareerCore = null;
        }

        [HttpGet]
        public HttpResponseMessage Get(string ID)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new CareerCore().GetByProfileID(ID), Configuration.Formatters.JsonFormatter);
        }

        [HttpPut]        
        public void Put([FromBody]CareerCoreEntity objCareerCoreEntity)
        {
            CareerCore objCareerCore = new CareerCore();
            using (objCareerCore as IDisposable)
            {
                objCareerCore.Edit(ref objCareerCoreEntity);
            }
            objCareerCore = null;
        }
    }
}

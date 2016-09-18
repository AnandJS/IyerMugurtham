using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mugurtham.Core.BasicInfo;
using Mugurtham.Common.Utilities;
using Mugurtham.Service.Controllers;

namespace Mugurtham.Service.Areas.Profile.Controllers.API
{
    [MugurthamBaseAPIController]
    [MugurthamAuthorizeAttribute(Mugurtham.Core.Constants.RoleIDForSangamAdmin, 
                                 Mugurtham.Core.Constants.RoleIDForUserProfile, 
                                 Mugurtham.Core.Constants.RoleIDForMugurthamAdmin)]
    public class BasicInfoAPIController : ApiController
    {
        [HttpPost]
        public void Add([FromBody]BasicInfoCoreEntity objBasicInfoCoreEntity)
        {
            BasicInfoCore objBasicInfoCore = new BasicInfoCore();
            using (objBasicInfoCore as IDisposable)
            {
                objBasicInfoCore.Add(ref objBasicInfoCoreEntity);
            }
            objBasicInfoCore = null;

        }

        [HttpGet]
        public HttpResponseMessage Get(string ID)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new BasicInfoCore().GetByProfileID(ID), Configuration.Formatters.JsonFormatter);
        }

        [HttpPut]
        public void Put([FromBody]BasicInfoCoreEntity objBasicInfoCoreEntity)
        {
            BasicInfoCore objBasicInfoCore = new BasicInfoCore();
            using (objBasicInfoCore as IDisposable)
                objBasicInfoCore.Edit(ref objBasicInfoCoreEntity);
            objBasicInfoCore = null;
        }
    }
}

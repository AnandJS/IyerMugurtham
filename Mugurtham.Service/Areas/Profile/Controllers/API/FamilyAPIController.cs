using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mugurtham.Core.Family;
using Mugurtham.Common.Utilities;
using Mugurtham.Service.Controllers;

namespace Mugurtham.Service.Areas.Profile.Controllers.API
{
    [MugurthamBaseAPIController]
    [MugurthamAuthorizeAttribute(Mugurtham.Core.Constants.RoleIDForSangamAdmin,
                                  Mugurtham.Core.Constants.RoleIDForUserProfile,
                                  Mugurtham.Core.Constants.RoleIDForMugurthamAdmin)]
    public class FamilyAPIController : ApiController
    {
        [HttpPost]
        public void Post([FromBody]FamilyCoreEntity objFamilyCoreEntity)
        {
            FamilyCore objFamilyCore = new FamilyCore();
            using (objFamilyCore as IDisposable)
            {
                objFamilyCore.Add(ref objFamilyCoreEntity);
            }
            objFamilyCore = null;
        }

        [HttpPut]
        public void Put([FromBody]FamilyCoreEntity objFamilyCoreEntity)
        {
            FamilyCore objFamilyCore = new FamilyCore();
            using (objFamilyCore as IDisposable)
            {
                objFamilyCore.Edit(ref objFamilyCoreEntity);
            }
            objFamilyCore = null;
        }

        [HttpGet]
        public HttpResponseMessage Get(string ID)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new FamilyCore().GetByProfileID(ID), Configuration.Formatters.JsonFormatter);
        }
    }
}

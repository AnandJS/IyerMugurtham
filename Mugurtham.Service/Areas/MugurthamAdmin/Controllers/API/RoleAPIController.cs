using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mugurtham.Core.Role;
using Mugurtham.Common.Utilities;
using Mugurtham.Service.Controllers;

namespace Mugurtham.Service.Areas.MugurthamAdmin.Controllers.API
{
    [MugurthamBaseAPIController]
    [MugurthamAuthorizeAttribute(Mugurtham.Core.Constants.RoleIDForMugurthamAdmin)]
    public class RoleAPIController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Add([FromBody]RoleCoreEntity objRoleCoreEntity)
        {            
            string strRoleID = string.Empty;
            RoleCore objRoleCore = new RoleCore();
            using (objRoleCore as IDisposable)
            {
                objRoleCore.Add(ref objRoleCoreEntity, out strRoleID);
            }
            objRoleCore = null;
            return Request.CreateResponse(HttpStatusCode.OK, strRoleID, Configuration.Formatters.JsonFormatter);

        }

        [HttpGet]
        public HttpResponseMessage Get(string ID)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new RoleCore().GetByID(ID), Configuration.Formatters.JsonFormatter);
        }
        
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            List<RoleCoreEntity> objSangamCoreEntityList = new List<RoleCoreEntity>();
            RoleCore objRoleCore = new RoleCore();
            using (objRoleCore as IDisposable)
                objRoleCore.GetAll(ref objSangamCoreEntityList);
            objRoleCore = null;
            return Request.CreateResponse(HttpStatusCode.OK, objSangamCoreEntityList,
              Configuration.Formatters.JsonFormatter);
        }

        [HttpPut]
        public void Put([FromBody]RoleCoreEntity objRoleCoreEntity)
        {
            RoleCore objRoleCore = new RoleCore();
            using (objRoleCore as IDisposable)
            {
                objRoleCore.Edit(ref objRoleCoreEntity);
            }
            objRoleCore = null;
        }
    }
}

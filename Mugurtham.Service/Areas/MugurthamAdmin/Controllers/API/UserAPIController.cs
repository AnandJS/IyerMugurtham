using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mugurtham.Core.User;
using Mugurtham.Common.Utilities;
using Mugurtham.Service.Controllers;

namespace Mugurtham.Service.Areas.MugurthamAdmin.Controllers.API
{
    [MugurthamBaseAPIController]
    [MugurthamAuthorizeAttribute(Mugurtham.Core.Constants.RoleIDForMugurthamAdmin)]
    public class UserAPIController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Add([FromBody]UserCoreEntity objUserCoreEntity)
        {
            string strUserID = string.Empty;
            UserCore objUserCore = new UserCore();
            using (objUserCore as IDisposable)
            {
                objUserCoreEntity.RoleID = Mugurtham.Core.Constants.RoleIDForSangamAdmin;
                objUserCore.Add(ref objUserCoreEntity, out strUserID);
            }
            objUserCore = null;
            return Request.CreateResponse(HttpStatusCode.OK, strUserID, Configuration.Formatters.JsonFormatter);

        }

        [HttpGet]
        [ActionName("Get")]
        public HttpResponseMessage Get(string ID)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new UserCore().GetByID(ID), Configuration.Formatters.JsonFormatter);
        }

        [HttpGet]
        [ActionName("LookupDTO")]
        public HttpResponseMessage GetLookupDTO()
        {
            List<Mugurtham.Core.Sangam.SangamCoreEntity> objSangamCoreEntityList = new List<Core.Sangam.SangamCoreEntity>();
            Mugurtham.Core.Sangam.SangamCore objSangamCore = new Core.Sangam.SangamCore();
            using (objSangamCore as IDisposable)
                objSangamCore.GetAll(ref objSangamCoreEntityList);
            return Request.CreateResponse(HttpStatusCode.OK, objSangamCoreEntityList, Configuration.Formatters.JsonFormatter);
        }

        [HttpGet]
        [ActionName("GetAll")]
        public HttpResponseMessage GetAll()
        {
            List<UserCoreEntity> objSangamCoreEntityList = new List<UserCoreEntity>();
            UserCore objUserCore = new UserCore();
            using (objUserCore as IDisposable)
                objUserCore.GetAll(ref objSangamCoreEntityList);
            objUserCore = null;
            return Request.CreateResponse(HttpStatusCode.OK, objSangamCoreEntityList,
              Configuration.Formatters.JsonFormatter);
        }
        [HttpGet]
        [ActionName("GetAllSangamUsers")]
        public HttpResponseMessage GetAllSangamUsers(string ID)
        {
            List<UserCoreEntity> objSangamCoreEntityList = new List<UserCoreEntity>();
            if (!string.IsNullOrWhiteSpace(ID))
            {
                UserCore objUserCore = new UserCore();
                using (objUserCore as IDisposable)
                    objUserCore.GetAllSangamUsers(ref objSangamCoreEntityList, ID);
                objUserCore = null;
            }
            return Request.CreateResponse(HttpStatusCode.OK, objSangamCoreEntityList,
              Configuration.Formatters.JsonFormatter);
        }

        [HttpPut]
        public void Put([FromBody]UserCoreEntity objUserCoreEntity)
        {
                UserCore objUserCore = new UserCore();
                using (objUserCore as IDisposable)
                {
                    objUserCore.Edit(ref objUserCoreEntity);
                }
                objUserCore = null;
        }

    }
}

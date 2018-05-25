using Bachelor.Core.Application.CreateGroup;
using Bachelor.Enterprise.Common;
using Bachelor.Enterprise.Common.Exceptions;
using Bachelor.Entities.CreateGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Bachelors.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateGroupController : ApiController
    {

        private readonly ICreateGroupApplication _createGroup;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createGroup"></param>
        public CreateGroupController(ICreateGroupApplication createGroup)
        {
            _createGroup = createGroup;
        }

        /// <summary>
        /// Get group details
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(APIResponse<List<GetGroupEntity>>))]
        [Route("api/CreateGroup/GetGroup")]
        public HttpResponseMessage GetGroup(int providerId)
        {
            try
            {
                var result = _createGroup.GetGroupDetails(providerId);
                return Request.CreateResponse(HttpStatusCode.OK, ServiceResponse<List<GetGroupEntity>>.Instance.BuildResponse(ResponseCodes.OK, result));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ServiceResponse.Instance.BuildResponse(ResponseCodes.SERVERERROR));
            }
        }

        /// <summary>
        /// Get group details
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(APIResponse<List<GetMembersEntity>>))]
        [Route("api/CreateGroup/GetMembers")]
        public HttpResponseMessage GetMembers(int providerGroupId)
        {
            try 
            {
                var result = _createGroup.GetMembers(providerGroupId);
                return Request.CreateResponse(HttpStatusCode.OK, ServiceResponse<List<GetMembersEntity>>.Instance.BuildResponse(ResponseCodes.OK, result));
            }
            catch (MembersNotAvailableException)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ServiceResponse.Instance.BuildResponse(ResponseCodes.NO_MEMBERS_FOUND));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ServiceResponse.Instance.BuildResponse(ResponseCodes.SERVERERROR));
            }
        }

        /// <summary>
        /// Creates Group for a provider
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(APIResponse<string>))]
        [Route("api/CreateGroup/CreateGroup")]
        public HttpResponseMessage CreateGroup(int providerId, string groupName)
        {
            try
            {
                var result = _createGroup.CreateGroup(providerId, groupName);
                return Request.CreateResponse(HttpStatusCode.OK, ServiceResponse<string>.Instance.BuildResponse(ResponseCodes.OK, result));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ServiceResponse.Instance.BuildResponse(ResponseCodes.SERVERERROR));
            }
        }

        /// <summary>
        /// Provider can add a member in a group
        /// </summary>
        /// <param name="memberProviderId"></param>
        /// <param name="adminGroupId"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(APIResponse<string>))]
        [Route("api/CreateGroup/AddMember")]
        public HttpResponseMessage AddMember(string memberProviderId, int adminGroupId)
        {
            try
            {
                var result = _createGroup.AddMember(memberProviderId, adminGroupId);
                return Request.CreateResponse(HttpStatusCode.OK, ServiceResponse<string>.Instance.BuildResponse(ResponseCodes.OK, result));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ServiceResponse.Instance.BuildResponse(ResponseCodes.SERVERERROR));
            }
        }
    }
}

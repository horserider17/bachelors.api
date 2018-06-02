using Bachelor.Core.Application.UserProfile;
using Bachelor.Enterprise.Common;
using Bachelor.Entities.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NLog;

namespace Bachelors.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UserProfileController : ApiBaseController
    {
        private readonly IUserProfileApplication _userProfileApplication;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfileApplication"></param>
        public UserProfileController(IUserProfileApplication userProfileApplication)
        {
            _userProfileApplication = userProfileApplication;
        }

        /// <summary>
        /// Gets user profile
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(APIResponse<GetProfileEntity>))]
        [Route("api/UserProfile/GetUserProfile")]
        public HttpResponseMessage GetUserProfile(string providerId)
        {
            try
            {
                var result = _userProfileApplication.GetUserProfile(providerId);
                return Request.CreateResponse(HttpStatusCode.OK, ServiceResponse<GetProfileEntity>.Instance.BuildResponse(ResponseCodes.OK, result));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Registers a new User
        /// </summary>
        /// <param name="getProfile"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(APIResponse<int>))]
        [Route("api/UserProfile/RegisterUser")]
        public HttpResponseMessage RegisterUser(GetProfileEntity getProfile)
        {
            try
            {
                var result = _userProfileApplication.RegisterUser(getProfile);
                return Request.CreateResponse(HttpStatusCode.OK, ServiceResponse<int>.Instance.BuildResponse(ResponseCodes.OK, result));
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex, ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ServiceResponse.Instance.BuildResponse(ResponseCodes.SERVERERROR));
            }
        }

        /// <summary>
        /// Searches a registered user
        /// </summary>
        /// <param name="getProfile"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(APIResponse<SearchUsersResponse>))]
        [Route("api/UserProfile/SearchUsers")]
        public HttpResponseMessage SearchUsers(string email)
        {
            try
            {
                var result = _userProfileApplication.SearchUsers(email);
                return Request.CreateResponse(HttpStatusCode.OK, ServiceResponse<List<SearchUsersResponse>>.Instance.BuildResponse(ResponseCodes.OK, result));
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex, ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ServiceResponse.Instance.BuildResponse(ResponseCodes.SERVERERROR));
            }
        }
    }
}

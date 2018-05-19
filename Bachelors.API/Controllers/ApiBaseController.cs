using Bachelor.Enterprise.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Bachelors.API.Controllers
{

    /// <summary>
    /// Base class for all the controllers
    /// </summary>
    [EnableCors("*", "*", "*")]
    public class ApiBaseController : ApiController
    {
        /// <summary>
        /// Returns success response
        /// </summary>
        /// <param name="httpStatus">HttpStatusCode</param>
        /// <returns>HttpResponseMessage object</returns>
        protected HttpResponseMessage BuildSuccessResponse(HttpStatusCode httpStatus)
        {
            return Request.CreateResponse(httpStatus);
        }

        /// <summary>
        /// Returns success response
        /// </summary>
        /// <param name="httpStatus">HttpStatusCode</param>
        /// <param name="resultValue">Result</param>
        /// <returns>HttpResponseMessage object</returns>
        protected HttpResponseMessage BuildSuccessResponse<T>(HttpStatusCode httpStatus, T resultValue)
        {
            return Request.CreateResponse(httpStatus, resultValue);
        }

        /// <summary>
        /// Returns error response
        /// </summary>
        /// <param name="responseCode">ResponseCodes</param>
        /// <returns>HttpResponseMessage object</returns>
        //protected HttpResponseMessage BuildErrorResponse(ResponseCodes responseCode)
        //{
        //    HttpStatusCode httpStatus = EnumManager.Instance.GetAttributeValue<ResponseCodes, HttpStatusAttribute, HttpStatusCode>(responseCode);

        //    var peErrorResponse = new SimplifyErrorModel
        //    {
        //        Code = (int)responseCode,
        //        Message = EnumManager.Instance.GetDescription(responseCode)
        //    };
        //    return Request.CreateResponse(httpStatus, peErrorResponse);
        //}

        /// <summary>
        /// Returns error response
        /// </summary>
        /// <param name="responseCode">ResponseCodes</param>
        /// <param name="httpStatus">HttpStatusCode</param>
        /// <returns></returns>
        //protected HttpResponseMessage BuildErrorResponse(ResponseCodes responseCode, HttpStatusCode httpStatus)
        //{
        //    var peErrorResponse = new SimplifyErrorModel
        //    {
        //        Code = (int)responseCode,
        //        Message = EnumManager.Instance.GetDescription(responseCode)
        //    };
        //    return Request.CreateResponse(httpStatus, peErrorResponse);
        //}
    }
}

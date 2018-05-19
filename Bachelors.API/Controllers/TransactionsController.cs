using Bachelor.Core.Application.Transactions;
using Bachelor.Enterprise.Common;
using Bachelor.Entities.Transactions;
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
    public class TransactionsController : ApiBaseController
    {
        private readonly ITransactionsApplication _transactionsApplication;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionsApplication"></param>
        public TransactionsController(ITransactionsApplication transactionsApplication)
        {
            _transactionsApplication = transactionsApplication;
        }

        /// <summary>
        /// Creates a balance sheet
        /// </summary>
        /// <param name="balanceSheetName"></param>
        /// <param name="totalAmount"></param>
        /// <param name="providerGroupId"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(APIResponse<string>))]
        [Route("api/Transactions/CreateBalanceSheet")]
        public HttpResponseMessage CreateBalanceSheet(string balanceSheetName, decimal totalAmount, int providerGroupId)
        {
            try
            {
                var result = _transactionsApplication.CreateBalanceSheet(balanceSheetName, totalAmount, providerGroupId);
                return Request.CreateResponse(HttpStatusCode.OK, ServiceResponse<string>.Instance.BuildResponse(ResponseCodes.OK, result));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ServiceResponse.Instance.BuildResponse(ResponseCodes.SERVERERROR));
            }
        }

        /// <summary>
        /// Provider can insert a item purchased
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="cost"></param>
        /// <param name="providerId"></param>
        /// <param name="providerGroupId"></param>
        /// <param name="grpBlncId"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(APIResponse<string>))]
        [Route("api/Transactions/CreateItem")]
        public HttpResponseMessage CreateItem(string itemName, decimal cost, string providerId, int providerGroupId, int grpBlncId)
        {
            try
            {
                var result = _transactionsApplication.CreateItem(itemName, cost, providerId, providerGroupId, grpBlncId);
                return Request.CreateResponse(HttpStatusCode.OK, ServiceResponse<string>.Instance.BuildResponse(ResponseCodes.OK, result));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ServiceResponse.Instance.BuildResponse(ResponseCodes.SERVERERROR));
            }
        }

        /// <summary>
        /// Gets total amount and expenditure of group
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <param name="grpBlncId"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(APIResponse<ExpenditureEntity>))]
        [Route("api/Transactions/GetExpenditure")]
        public HttpResponseMessage GetExpenditure(int providerGroupId, int grpBlncId)
        {
            try
            {
                var result = _transactionsApplication.GetExpenditure(providerGroupId, grpBlncId);
                return Request.CreateResponse(HttpStatusCode.OK, ServiceResponse<ExpenditureEntity>.Instance.BuildResponse(ResponseCodes.OK, result));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ServiceResponse.Instance.BuildResponse(ResponseCodes.SERVERERROR));
            }
        }

        /// <summary>
        /// Gets list of individual expenditure of a group
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <param name="grpBlncId"></param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(APIResponse<ExpenditureEntity>))]
        [Route("api/Transactions/GetIndividualExpenditure")]
        public HttpResponseMessage GetIndividualExpenditure(int providerGroupId, int grpBlncId)
        {
            try
            {
                var result = _transactionsApplication.GetIndividualExpenditure(providerGroupId, grpBlncId);
                return Request.CreateResponse(HttpStatusCode.OK, ServiceResponse<ExpenditureEntity>.Instance.BuildResponse(ResponseCodes.OK, result));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ServiceResponse.Instance.BuildResponse(ResponseCodes.SERVERERROR));
            }
        }

        /// <summary>
        /// Gets list of balance sheets available for a group
        /// </summary>
        /// <param name="providerGroupId"></param
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(APIResponse<List<BalanceSheetEntityList>>))]
        [Route("api/Transactions/GetBalanceSheet")]
        public HttpResponseMessage GetBalanceSheet(int providerGroupId)
        {
            try
            {
                var result = _transactionsApplication.GetBalanceSheet(providerGroupId);
                return Request.CreateResponse(HttpStatusCode.OK, ServiceResponse<List<BalanceSheetEntityList>>.Instance.BuildResponse(ResponseCodes.OK, result));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ServiceResponse.Instance.BuildResponse(ResponseCodes.SERVERERROR));
            }
        }
    }
}

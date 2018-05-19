
namespace Bachelor.Enterprise.Common
{
    /// <summary>
    /// Manages service response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T> : SingletonBase<ServiceResponse<T>>
    {
        private ServiceResponse()
        {
        }

        /// <summary>
        /// Builds the service response
        /// </summary>
        /// <param name="code">ResponseCodes</param>
        /// <param name="data">Object of type T</param>
        /// <returns>SimplifyResponse object</returns>
        public APIResponse<T> BuildResponse(ResponseCodes code, T data)
        {
            var peResonse = new APIResponse<T>
            {
                Code = (int)code,
                Message = EnumManager.Instance.GetDescription(code),
                Data = data
            };

            return peResonse;
        }
    }

    /// <summary>
    /// Manages service response
    /// </summary>
    public class ServiceResponse : SingletonBase<ServiceResponse>
    {
        private ServiceResponse()
        { }

        /// <summary>
        /// Builds the service response
        /// </summary>
        /// <param name="code">ResponseCodes</param>
        /// <returns>SimplifyResponse object</returns>
        public APIResponse BuildResponse(ResponseCodes code)
        {
            var peResponse = new APIResponse
            {
                Code = (int)code,
                Message = EnumManager.Instance.GetDescription(code)
            };
            return peResponse;
        }
    }
}

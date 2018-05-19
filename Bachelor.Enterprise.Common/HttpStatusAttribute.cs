using System;
using System.Net;


namespace Bachelor.Enterprise.Common
{
    /// <summary>
    /// Custom attribute to declare HttpStatus
    /// </summary>
    public sealed class HttpStatusAttribute : Attribute, IEnumAttribute<HttpStatusCode>
    {
        private HttpStatusCode oK;

        public HttpStatusAttribute(HttpStatusCode oK)
        {
            this.oK = oK;
        }

        /// <summary>
        /// Gets HttpStatusCode value
        /// </summary>
        public HttpStatusCode Value { get; }
    }
}

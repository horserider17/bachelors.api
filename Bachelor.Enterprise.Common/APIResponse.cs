using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor.Enterprise.Common
{
    /// <summary>
    /// SimplifyResponse object
    /// </summary>
    /// <typeparam name="T">Type T</typeparam>
    [DataContract(Name = "APIResponse{0}")]
    public class APIResponse<T>
    {
        /// <summary>
        /// service custom code
        /// </summary>
        [DataMember]
        public int Code { get; set; }

        /// <summary>
        /// service custom message
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// response object
        /// </summary>
        [DataMember]
        public T Data { get; set; }
    }

    /// <summary>
    /// SimplifyResponse object
    /// </summary>
    public class APIResponse
    {
        /// <summary>
        /// service custom code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// service custom message
        /// </summary>
        public string Message { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor.Entities.UserProfile
{
    public class SearchUsersResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public string providerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int providerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string imageUrl { get; set; }
    }
}

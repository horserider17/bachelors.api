using Bachelor.Entities.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor.Core.Application.UserProfile
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserProfileApplication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns></returns>
        GetProfileEntity GetUserProfile(string providerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getProfile"></param>
        /// <returns></returns>
        string RegisterUser(GetProfileEntity getProfile);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bachelor.Entities.UserProfile;
using Bachelor.DataAccess.UserProfile.Interfaces;

namespace Bachelor.Core.Application.UserProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class UserProfileApplication : IUserProfileApplication
    {
        private readonly IUserProfileDAL _userProfileDAL;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfileDAL"></param>
        public UserProfileApplication(IUserProfileDAL userProfileDAL)
        {
            _userProfileDAL = userProfileDAL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns></returns>
        public GetProfileEntity GetUserProfile(string providerId)
        {
            var getUserProfile = _userProfileDAL.GetUserProfile(providerId);
            return getUserProfile;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getProfile"></param>
        /// <returns></returns>
        public string RegisterUser(GetProfileEntity getProfile)
        {
            var result = _userProfileDAL.RegisterUser(getProfile);

            if (result)
                return "Registered Successfully";
            else
                return "Error";
        }
    }
}

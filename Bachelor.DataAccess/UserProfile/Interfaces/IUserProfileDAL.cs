using Bachelor.Entities.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor.DataAccess.UserProfile.Interfaces
{
    public interface IUserProfileDAL
    {
        GetProfileEntity GetUserProfile(string providerId);

        int RegisterUser(GetProfileEntity getProfile);

        List<SearchUsersResponse> SearchUsers(string email);
    }
}

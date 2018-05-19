using Bachelor.DataAccess.UserProfile.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bachelor.Entities.UserProfile;
using Bachelor.DataAccess.Common;

namespace Bachelor.DataAccess.UserProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class UserProfileDAL : IUserProfileDAL
    {
        private Db _db;

        /// <summary>
        /// 
        /// </summary>
        public UserProfileDAL()
        {
            _db = new Db();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns></returns>
        public GetProfileEntity GetUserProfile(string providerId)
        {
            Guid providerGuid;
            Guid.TryParse(providerId, out providerGuid);

            object[] param = { providerGuid };

            var dbCommand = _db.GetCommand("dbo.GET_PROVIDER", param);
            var providerDataReader = _db.ExecuteReader(dbCommand);

            if (providerDataReader == null)
                throw new Exception();

            GetProfileEntity getProfile = null;

            while (providerDataReader.Read())
            {
                getProfile = new GetProfileEntity
                {
                    FirstName = providerDataReader["FirstName"].ToString(),
                    LastName = providerDataReader["LastName"].ToString(),
                    Mobile =providerDataReader["Mobile"].ToString()
                };
            }

            return getProfile;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getProfile"></param>
        /// <returns></returns>
        public bool RegisterUser(GetProfileEntity getProfile)
        {
            var providerGuid = Guid.NewGuid();

            object[] param = { getProfile.FirstName, getProfile.LastName, getProfile.Mobile, providerGuid };

            var dbCommand = _db.GetCommand("dbo.INSERT_INTO_PROVIDER", param);

            var result = _db.ExecuteNonQuery(dbCommand);

            return result > 0;
        }
    }
}

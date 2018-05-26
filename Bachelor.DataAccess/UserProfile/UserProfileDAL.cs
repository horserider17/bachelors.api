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
                    Email =providerDataReader["Mobile"].ToString()
                };
            }

            return getProfile;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getProfile"></param>
        /// <returns></returns>
        public int RegisterUser(GetProfileEntity getProfile)
        {
            var providerGuid = Guid.NewGuid();

            object[] param = { getProfile.FirstName, getProfile.LastName, getProfile.Email, providerGuid, getProfile.UserId};

            var dbCommand = _db.GetStoredProcCommand("dbo.INSERT_INTO_PROVIDER");
            _db.AddInParameter(dbCommand, "@firstname", System.Data.DbType.String, getProfile.FirstName);
            _db.AddInParameter(dbCommand, "@lastname", System.Data.DbType.String, getProfile.LastName);
            _db.AddInParameter(dbCommand, "@email", System.Data.DbType.String, getProfile.Email);
            _db.AddInParameter(dbCommand, "@providerguid", System.Data.DbType.Guid, providerGuid);
            _db.AddInParameter(dbCommand, "@userid", System.Data.DbType.String, getProfile.UserId);
            _db.AddOutParameter(dbCommand, "@providerid", System.Data.DbType.Int32,0);

            var result = _db.ExecuteNonQuery(dbCommand);

            int providerId = Convert.ToInt32(_db.GetParameterValue(dbCommand, "@providerid"));

            return providerId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public SearchUsersResponse SearchUsers(string email)
        {
            object[] param = { email };

            var dbCommand = _db.GetCommand("dbo.GET_SEARCH_USER", param);
            var userDetailsReader = _db.ExecuteReader(dbCommand);

            if (userDetailsReader == null)
                throw new Exception();

            SearchUsersResponse userDetails = null;

            while (userDetailsReader.Read())
            {
                userDetails = new SearchUsersResponse
                {
                    email = userDetailsReader["email"].ToString(),
                    providerId = Convert.ToInt32(userDetailsReader["providerid"])
                };
            }

            return userDetails;
        }
    }
}

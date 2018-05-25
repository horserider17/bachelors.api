using System;
using System.Data;
using Bachelor.DataAccess.Common;
using Bachelor.DataAccess.CreateGroup.Interfaces;
using Bachelor.Entities.CreateGroup;
using System.Collections.Generic;
using Bachelor.Enterprise.Common.Exceptions;

namespace Bachelor.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateGroupDAL : ICreateGroupDAL
    {
        private Db _db;

        /// <summary>
        /// 
        /// </summary>
        public CreateGroupDAL()
        {
            _db = new Db();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<GetGroupEntity> GetGroup(int providerId)
        {
            object[] param = { providerId };

            var dbCommand = _db.GetCommand("GET_PROVIDER_GROUP_DETAILS", param);

            var providerDataReader = _db.ExecuteReader(dbCommand);

            if (providerDataReader == null || providerDataReader.FieldCount == 0)
                throw new Exception();

            GetGroupEntity getGroup = null;

            var getGroupList = new List<GetGroupEntity>();

            while (providerDataReader.Read())
            {
                getGroup = new GetGroupEntity
                {
                    Providergroupid = Convert.ToInt32(providerDataReader["ProviderGroupId"]),
                    GroupName = providerDataReader["GroupName"].ToString(),
                    IsAdmin = Convert.ToBoolean(providerDataReader["IsAdmin"])
                };
                getGroupList.Add(getGroup);
            }

            return getGroupList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerId"></param>
        public bool CreateGroup(string providerId, string groupName)
        {
            Guid providerGuid;
            Guid.TryParse(providerId, out providerGuid);

            object[] param = { providerGuid, groupName };

            var dbCommand = _db.GetCommand("INSERT_INTO_CREATE_GROUP", param);

            var result = _db.ExecuteNonQuery(dbCommand);

            return result > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberProviderId"></param>
        /// <param name="adminGroupId"></param>
        /// <returns></returns>
        public bool AddMember(string memberProviderId, int adminGroupId)
        {
            Guid providerGuid;
            Guid.TryParse(memberProviderId, out providerGuid);

            object[] param = { providerGuid, adminGroupId };

            var dbCommand = _db.GetCommand("INSERT_INTO_GROUP_MEMBER", param);

            var result = _db.ExecuteNonQuery(dbCommand);

            return result > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <returns></returns>
        public List<GetMembersEntity> GetMembers(int providerGroupId)
        {
            object[] param = { providerGroupId };

            var dbCommand = _db.GetCommand("GET_PROVIDER_GROUP_MEMBER_DETAILS", param);

            var memberDataReader = _db.ExecuteReader(dbCommand);

           // if (memberDataReader == null || memberDataReader.RecordsAffected == -1)
                //throw new MembersNotAvailableException();

            GetMembersEntity getMembers = null;

            var getgetMembersList = new List<GetMembersEntity>();

            while (memberDataReader.Read())
            {
                getMembers = new GetMembersEntity
                {
                    ProviderGuid = memberDataReader.GetGuid(memberDataReader.GetOrdinal("ProviderGuid")),
                    FirstName = memberDataReader["FirstName"].ToString(),
                    IsAdmin = Convert.ToBoolean(memberDataReader["IsAdmin"])
                };
                getgetMembersList.Add(getMembers);
            }

            return getgetMembersList;
        }
    }
}

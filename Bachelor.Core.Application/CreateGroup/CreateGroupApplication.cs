using Bachelor.DataAccess.CreateGroup.Interfaces;
using Bachelor.Entities.CreateGroup;
using System.Collections.Generic;
using System;

namespace Bachelor.Core.Application.CreateGroup
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateGroupApplication : ICreateGroupApplication
    {
        private readonly ICreateGroupDAL _createGroupDAL;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createGroupDAL"></param>
        public CreateGroupApplication(ICreateGroupDAL createGroupDAL)
        {
            _createGroupDAL = createGroupDAL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<GetGroupEntity> GetGroupDetails(int providerId)
        {
            var getGroupDetails = _createGroupDAL.GetGroup(providerId);
            return getGroupDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        public string CreateGroup(string providerId, string groupName)
        {
            var result =  _createGroupDAL.CreateGroup(providerId, groupName);

            if (result)
                return "Group created successfully";
            else
                return "Error";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberProviderId"></param>
        /// <param name="adminGroupId"></param>
        /// <returns></returns>
        public string AddMember(string memberProviderId, int adminGroupId)
        {
            var result = _createGroupDAL.AddMember(memberProviderId, adminGroupId);

            if (result)
                return "Member added successfully";
            else
                return "Error";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <returns></returns>
        public List<GetMembersEntity> GetMembers(int providerGroupId)
        {
            var getMemberDetails = _createGroupDAL.GetMembers(providerGroupId);
            return getMemberDetails;
        }
    }
}

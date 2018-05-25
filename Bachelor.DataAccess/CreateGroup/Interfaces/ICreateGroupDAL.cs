using Bachelor.Entities.CreateGroup;
using System.Collections.Generic;

namespace Bachelor.DataAccess.CreateGroup.Interfaces
{
    public interface ICreateGroupDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns></returns>
        List<GetGroupEntity> GetGroup(int providerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerId"></param>
        /// <param name="balanceSheetName"></param>
        /// <returns></returns>
        bool CreateGroup(int providerId, string balanceSheetName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberProviderId"></param>
        /// <param name="adminGroupId"></param>
        /// <returns></returns>
        bool AddMember(string memberProviderId, int adminGroupId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <returns></returns>
        List<GetMembersEntity> GetMembers(int providerGroupId);

    }
}

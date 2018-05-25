using Bachelor.Entities.CreateGroup;
using System.Collections.Generic;

namespace Bachelor.Core.Application.CreateGroup
{
   public interface ICreateGroupApplication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<GetGroupEntity> GetGroupDetails(int providerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerId"></param>
        /// <param name="balanceSheetName"></param>
        /// <returns></returns>
        string CreateGroup(int providerId, string balanceSheetName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberProviderId"></param>
        /// <param name="adminGroupId"></param>
        /// <returns></returns>
        string AddMember(string memberProviderId, int adminGroupId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <returns></returns>
        List<GetMembersEntity> GetMembers(int providerGroupId);
    }
}


using Bachelor.Entities.Transactions;
using System.Collections.Generic;

namespace Bachelor.DataAccess.Transactions.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITransactionsDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="balanceSheetName"></param>
        /// <param name="totalAmount"></param>
        /// <param name="providerGroupId"></param>
        /// <returns></returns>
        bool CreateBalanceSheet(string balanceSheetName, decimal totalAmount, int providerGroupId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="cost"></param>
        /// <param name="providerId"></param>
        /// <param name="providerGroupId"></param>
        /// <param name="grpBlncId"></param>
        /// <returns></returns>
        bool CreateItem(string itemName, decimal cost, string providerId, int providerGroupId, int grpBlncId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <param name="grpBlncId"></param>
        /// <returns></returns>
        ExpenditureEntity GetExpenditure(int providerGroupId, int grpBlncId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <param name="grpBlncId"></param>
        /// <returns></returns>
        ExpenditureEntity GetIndividualExpenditure(int providerGroupId, int grpBlncId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <returns></returns>
        List<BalanceSheetEntityList> GetBalanceSheet(int providerGroupId);

    }
}

using Bachelor.Entities.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor.Core.Application.Transactions
{
    public interface ITransactionsApplication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="balanceSheetName"></param>
        /// <param name="totalAmount"></param>
        /// <param name="providerGroupId"></param>
        /// <returns></returns>
        string CreateBalanceSheet(string balanceSheetName, decimal totalAmount, int providerGroupId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="cost"></param>
        /// <param name="providerId"></param>
        /// <param name="providerGroupId"></param>
        /// <param name="grpBlncId"></param>
        /// <returns></returns>
        string CreateItem(string itemName, decimal cost, string providerId, int providerGroupId, int grpBlncId);

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
        List<ExpenditureEntityList> GetIndividualExpenditure(int providerGroupId, int grpBlncId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <returns></returns>
        List<BalanceSheetEntityList> GetBalanceSheet(int providerGroupId);
    }
}

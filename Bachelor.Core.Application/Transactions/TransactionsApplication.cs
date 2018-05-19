using Bachelor.DataAccess.Transactions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bachelor.Entities.Transactions;

namespace Bachelor.Core.Application.Transactions
{
    public  class TransactionsApplication : ITransactionsApplication
    {
        private readonly ITransactionsDAL _transactionsDAL;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionsDAL"></param>
        public TransactionsApplication(ITransactionsDAL transactionsDAL)
        {
            _transactionsDAL = transactionsDAL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="balanceSheetName"></param>
        /// <param name="totalAmount"></param>
        /// <param name="providerGroupId"></param>
        /// <returns></returns>
        public string CreateBalanceSheet(string balanceSheetName, decimal totalAmount, int providerGroupId)
        {
            var result = _transactionsDAL.CreateBalanceSheet(balanceSheetName, totalAmount, providerGroupId);

            if (result)
                return "Amount added successfully";
            else
                return "Error";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="cost"></param>
        /// <param name="providerId"></param>
        /// <param name="providerGroupId"></param>
        /// <param name="grpBlncId"></param>
        /// <returns></returns>
        public string CreateItem(string itemName, decimal cost, string providerId, int providerGroupId, int grpBlncId)
        {
            var result = _transactionsDAL.CreateItem(itemName, cost, providerId, providerGroupId, grpBlncId);

            if (result)
                return "Item added successfully";
            else
                return "Error";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <returns></returns>
        public List<BalanceSheetEntityList> GetBalanceSheet(int providerGroupId)
        {
            var result = _transactionsDAL.GetBalanceSheet(providerGroupId);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <param name="grpBlncId"></param>
        /// <returns></returns>
        public ExpenditureEntity GetExpenditure(int providerGroupId, int grpBlncId)
        {
            var result = _transactionsDAL.GetExpenditure(providerGroupId, grpBlncId);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <param name="grpBlncId"></param>
        /// <returns></returns>
        public List<ExpenditureEntityList> GetIndividualExpenditure(int providerGroupId, int grpBlncId)
        {
            var result = _transactionsDAL.GetIndividualExpenditure(providerGroupId, grpBlncId);
            return result;
        }
    }
}

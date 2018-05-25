using Bachelor.DataAccess.Common;
using Bachelor.DataAccess.Transactions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bachelor.Entities.Transactions;

namespace Bachelor.DataAccess.Transactions
{
    public class TransactionsDAL : ITransactionsDAL
    {
        private Db _db;

        /// <summary>
        /// 
        /// </summary>
        public TransactionsDAL()
        {
            _db = new Db();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="balanceSheetName"></param>
        /// <param name="totalAmount"></param>
        /// <param name="providerGroupId"></param>
        /// <returns></returns>
        public bool CreateBalanceSheet(string balanceSheetName, decimal totalAmount, int providerGroupId)
        {
            object[] param = { balanceSheetName, totalAmount, providerGroupId };

            var dbCommand = _db.GetCommand("INSERT_INTO_GROUP_BALANCE", param);

            var result = _db.ExecuteNonQuery(dbCommand);

            return result > 0;
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
        public bool CreateItem(string itemName, decimal cost, int providerId, int providerGroupId, int grpBlncId)
        {
            object[] param = { itemName, cost, providerId, providerGroupId, grpBlncId };

            var dbCommand = _db.GetCommand("INSERT_INTO_ITEM_COST", param);

            var result = _db.ExecuteNonQuery(dbCommand);

            return result > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <returns></returns>
        public List<BalanceSheetEntityList> GetBalanceSheet(int providerGroupId)
        {
            BalanceSheetEntityList balanceSheet = null;

            var balanceSheetList = new List<BalanceSheetEntityList>();

            object[] param = { providerGroupId };

            var dbCommand = _db.GetCommand("GET_BALANCE_SHEET_LIST", param);

            var expenditureReader = _db.ExecuteReader(dbCommand);

            while (expenditureReader.Read())
            {
                balanceSheet = new BalanceSheetEntityList
                {
                    BalanceSheetId = Convert.ToInt32(expenditureReader["GrpblncId"]),
                    BalanceSheetName = expenditureReader["BlncsheetName"].ToString()
                };
                balanceSheetList.Add(balanceSheet);
            }
            return balanceSheetList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <param name="grpBlncId"></param>
        /// <returns></returns>
        public ExpenditureEntity GetExpenditure(int providerGroupId, int grpBlncId)
        {
            ExpenditureEntity expenditureEntity = null;

            object[] param = { providerGroupId, grpBlncId };

            var dbCommand = _db.GetCommand("GET_TOTAL_EXPENDITURE", param);

            var expenditureReader = _db.ExecuteReader(dbCommand);

            while(expenditureReader.Read())
            {
                expenditureEntity = new ExpenditureEntity
                {
                    TotalAmount = Convert.ToDecimal(expenditureReader["TotalAmount"]),
                    RemainingAmount = Convert.ToDecimal(expenditureReader["RemainingAmount"])
                };

            }
            return expenditureEntity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerGroupId"></param>
        /// <param name="grpBlncId"></param>
        /// <returns></returns>
        public ExpenditureEntity GetIndividualExpenditure(int providerGroupId, int grpBlncId)
        {
            ExpenditureEntity expenditureEntity = null;
            ExpenditureEntityList expenditure = null;
            ItemList itemData = null;

            var expenditureList = new List<ExpenditureEntityList>();

            object[] param = { providerGroupId, grpBlncId };

            var dbCommand = _db.GetCommand("GET_INDIVIDUAL_EXPENDITURE_LIST", param);

            var expenditureReader = _db.ExecuteDataSet(dbCommand);

            for (int i = 0; i < expenditureReader.Tables[0].Rows.Count; i++)
            {
                var data = expenditureReader.Tables[0].Rows[i];
                expenditureEntity = new ExpenditureEntity
                {
                    TotalAmount = Convert.ToDecimal(data["totalamount"]),
                    RemainingAmount = Convert.ToDecimal(data["remainingamount"])
                };
            }

            for (int i = 0; i < expenditureReader.Tables[1].Rows.Count; i++)
            {
                var data = expenditureReader.Tables[1].Rows[i];
                expenditure = new ExpenditureEntityList
                {
                    ProviderId = Convert.ToInt32(data["providerid"]),
                    ProviderName = data["firstname"].ToString(),
                    IndividualTotal = Convert.ToDecimal(data["total"])
                };
                var itemlist = new List<ItemList>();
                for (int j = 0; j < expenditureReader.Tables[2].Rows.Count; j++)
                {
                    var itemDetails = expenditureReader.Tables[2].Rows[j];
                    if(expenditure.ProviderId == Convert.ToInt32(itemDetails["providerid"]))
                    {
                        itemData = new ItemList
                        {
                            Cost = Convert.ToDecimal(itemDetails["cost"]),
                            ItemName = itemDetails["itemname"].ToString(),
                            SpentDate = Convert.ToString(itemDetails["createddate"]),
                        };
                        itemlist.Add(itemData);
                    }
                }
                expenditure.ItemList = itemlist;
                expenditureList.Add(expenditure);
            }

            expenditureEntity.ExpenditureEntityList = expenditureList;

            return expenditureEntity;
        }
    }
}

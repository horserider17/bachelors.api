
using System.Collections.Generic;

namespace Bachelor.Entities.Transactions
{
    public class ExpenditureEntity
    {
        public decimal TotalAmount { get; set; }

        public decimal RemainingAmount { get; set; }

        public List<ExpenditureEntityList> ExpenditureEntityList { get; set; }
    }
}

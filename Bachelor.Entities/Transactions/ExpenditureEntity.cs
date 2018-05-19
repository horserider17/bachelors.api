
namespace Bachelor.Entities.Transactions
{
    public class ExpenditureEntity
    {
        public decimal TotalAmount { get; set; }

        public decimal RemainingAmount { get; set; }

        public ExpenditureEntityList ExpenditureEntityList { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor.Entities.Transactions
{
    public class ExpenditureEntityList
    {
        /// <summary>
        /// 
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? SpentDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProviderName { get; set; }
    }
}

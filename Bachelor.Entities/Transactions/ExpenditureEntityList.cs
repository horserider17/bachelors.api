﻿using System;
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
        public int ProviderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal IndividualTotal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ItemList> ItemList { get; set; }
    }
}

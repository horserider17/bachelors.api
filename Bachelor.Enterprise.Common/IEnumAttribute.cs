using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor.Enterprise.Common
{
    /// <summary>
    /// Custom attribute for all enums
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEnumAttribute<T>
    {
        /// <summary>
        /// Generic type Value
        /// </summary>
        T Value { get; }
    }
}

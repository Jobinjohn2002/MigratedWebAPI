using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// BulkOperationResponseContract
    /// </summary>
    public class BulkOperationResponseContract<T> : OperationResponseContract
    {
        /// <summary>
        /// Gets or sets FailedItems
        /// </summary>
        public List<T> FailedItems { get; set; } = new List<T>();
    }
}

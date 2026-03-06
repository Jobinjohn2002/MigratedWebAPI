using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemExceptionResponseContract
    /// </summary>
    public class ItemExceptionResponseContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        public int? ItemInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ItemInstanceIdentifierTypeId
        /// </summary>
        public short ItemInstanceIdentifierTypeId { get; set; }
        /// <summary>
        /// Gets or sets ScannedBarcode
        /// </summary>
        public string ScannedBarcode { get; set; }
    }
}

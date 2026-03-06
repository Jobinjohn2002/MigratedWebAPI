using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemInstanceIdDataContract
    /// </summary>
    public class ItemInstanceIdDataContract
    {
        /// <summary>
        /// Gets or sets Alias
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// Gets or sets Barcode
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// Gets or sets HumanReadableBarcode
        /// </summary>
        public string HumanReadableBarcode { get; set; }
        /// <summary>
        /// Gets or sets ItemIdentifierTypeId
        /// </summary>
        public short ItemIdentifierTypeId { get; set; }

    }
}
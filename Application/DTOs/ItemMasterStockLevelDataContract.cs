using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemMasterStockLevelDataContract
    /// </summary>
    public class ItemMasterStockLevelDataContract
    {
        /// <summary>
        /// Gets or sets ItemMasterID
        /// </summary>
        public int ItemMasterID { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets ExternalID
        /// </summary>
        public string ExternalID { get; set; }
        /// <summary>
        /// Gets or sets LocationID
        /// </summary>
        public int LocationID { get; set; }
        /// <summary>
        /// Gets or sets LocationName
        /// </summary>
        public string LocationName { get; set; }
        /// <summary>
        /// Gets or sets Amount
        /// </summary>
        public int Amount { get; set; }
    }
}

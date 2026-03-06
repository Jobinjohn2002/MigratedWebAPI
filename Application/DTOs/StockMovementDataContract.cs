using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// StockMovementDataContract
    /// </summary>
    public class StockMovementDataContract
    {
        /// <summary>
        /// Gets or sets StockMovementID
        /// </summary>
        public int StockMovementID { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterID
        /// </summary>
        public int ItemMasterID { get; set; }
        /// <summary>
        /// Gets or sets ItemExternalID
        /// </summary>
        public string ItemExternalID { get; set; }
        public int? SourceStockLocationID { get; set; }
        public int? DestinationStockLocationID { get; set; }
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserID
        /// </summary>
        public int CreatedUserID { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceID
        /// </summary>
        public string ContainerInstanceID { get; set; }
    }
}

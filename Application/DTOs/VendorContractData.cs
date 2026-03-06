using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// VendorContractData
    /// </summary>
    public class VendorContractData
    {
        /// <summary>
        /// Gets or sets ContractId
        /// </summary>
        public int ContractId { get; set; }
        /// <summary>
        /// Gets or sets VendorId
        /// </summary>
        public int VendorId { get; set; }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets Modified
        /// </summary>
        public DateTime Modified { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets VendorName
        /// </summary>
        public string VendorName { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets VendorMaintenanceText
        /// </summary>
        public string VendorMaintenanceText { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceActivityId
        /// </summary>
        public int MaintenanceActivityId { get; set; }
        /// <summary>
        /// Gets or sets ContractVendorMaintenanceData
        /// </summary>
        public IList<ContractVendorMaintenanceData> ContractVendorMaintenanceData { get; set; }
        /// <summary>
        /// Gets or sets VendorContractId
        /// </summary>
        public string VendorContractId { get; set; }
    }
}

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
    /// VendorActivityData
    /// </summary>
    public class VendorActivityData
    {
        public VendorActivityData(IVendorMaintenanceActivity genericObj)
        {
            VendorMaintenanceActivityId = genericObj.VendorMaintenanceActivityId;
            MaintenanceActivityId = genericObj.MaintenanceActivityId.GetValueOrDefault();
            Created = genericObj.Created.GetValueOrDefault();
            Text = genericObj.Text;
            Code = genericObj.Code;
            CreatedUserId = genericObj.CreatedUserId.GetValueOrDefault();
        }

        public VendorActivityData()
        {
        }
        /// <summary>
        /// Gets or sets VendorMaintenanceActivityId
        /// </summary>
        public int VendorMaintenanceActivityId { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceActivityId
        /// </summary>
        public int MaintenanceActivityId { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets Selected
        /// </summary>
        public bool Selected { get; set; }
        /// <summary>
        /// Gets or sets Selectable
        /// </summary>
        public bool Selectable { get; set; }
        /// <summary>
        /// Gets or sets InUseOnMaintenanceContract
        /// </summary>
        public bool InUseOnMaintenanceContract { get; set; }
        /// <summary>
        /// Gets or sets InUseOnMaintenanceReport
        /// </summary>
        public bool InUseOnMaintenanceReport { get; set; }
        /// <summary>
        /// Gets or sets VendorMaintenanceText
        /// </summary>
        public string VendorMaintenanceText { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceActivityCode
        /// </summary>
        public string MaintenanceActivityCode { get; set; }
        /// <summary>
        /// Gets or sets ContractCost
        /// </summary>
        public decimal ContractCost { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceActivityExternalId
        /// </summary>
        public string MaintenanceActivityExternalId { get; set; }
    }
}

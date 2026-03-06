using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class Contract
    {
        public Contract()
        {
            this.ContractVendorMaintenances = new HashSet<ContractVendorMaintenance>();
        }
    
        /// <summary>
        /// Gets or sets ContractId
        /// </summary>
        public int ContractId { get; set; }
        /// <summary>
        /// Gets or sets VendorId
        /// </summary>
        public int VendorId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public Nullable<int> CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets VendorContractId
        /// </summary>
        public string VendorContractId { get; set; }
    
        /// <summary>
        /// Gets or sets CustomerDefinition
        /// </summary>
        public virtual CustomerDefinition CustomerDefinition { get; set; }
        /// <summary>
        /// Gets or sets Vendor
        /// </summary>
        public virtual Vendor Vendor { get; set; }
        /// <summary>
        /// Gets or sets ContractVendorMaintenances
        /// </summary>
        public virtual ICollection<ContractVendorMaintenance> ContractVendorMaintenances { get; set; }
    }
}

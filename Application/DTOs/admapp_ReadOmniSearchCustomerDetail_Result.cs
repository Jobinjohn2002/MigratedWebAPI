using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadOmniSearchCustomerDetail_Result
    {
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets CustomerStatusId
        /// </summary>
        public byte CustomerStatusId { get; set; }
        /// <summary>
        /// Gets or sets CustomerGroupid
        /// </summary>
        public Nullable<int> CustomerGroupid { get; set; }
        /// <summary>
        /// Gets or sets customerdefinitionid
        /// </summary>
        public int customerdefinitionid { get; set; }
        /// <summary>
        /// Gets or sets CustomerGroupName
        /// </summary>
        public string CustomerGroupName { get; set; }
        /// <summary>
        /// Gets or sets Facilityid
        /// </summary>
        public short Facilityid { get; set; }
        /// <summary>
        /// Gets or sets FacilitName
        /// </summary>
        public string FacilitName { get; set; }
        /// <summary>
        /// Gets or sets Revision
        /// </summary>
        public short Revision { get; set; }
        public System.DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets IsArchived
        /// </summary>
        public int IsArchived { get; set; }
    }
}

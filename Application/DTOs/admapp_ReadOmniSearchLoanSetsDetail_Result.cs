using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadOmniSearchLoanSetsDetail_Result
    {
        /// <summary>
        /// Gets or sets LoanSetId
        /// </summary>
        public int LoanSetId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        /// <summary>
        /// Gets or sets NoOfTrays
        /// </summary>
        public Nullable<int> NoOfTrays { get; set; }
        /// <summary>
        /// Gets or sets LoanSupplier
        /// </summary>
        public string LoanSupplier { get; set; }
        /// <summary>
        /// Gets or sets Consignment
        /// </summary>
        public bool Consignment { get; set; }
        public Nullable<System.DateTime> DateRequired { get; set; }
        public System.DateTime ReturnDate { get; set; }
        /// <summary>
        /// Gets or sets StatusId
        /// </summary>
        public short StatusId { get; set; }
    }
}

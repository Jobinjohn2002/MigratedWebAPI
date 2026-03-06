using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IOmniSearchLoanSetsDetail
    /// </summary>
    public interface IOmniSearchLoanSetsDetail
    {
        /// <summary>
        /// Gets or sets the loanset id.
        /// </summary>
        /// <value>The  loanset id.</value>
        /// <remarks></remarks>
        int LoanSetId { get; set; }

        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The  external id.</value>
        /// <remarks></remarks>
        string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryDate
        /// </summary>
        /// <value>The  DeliveryDate.</value>
        /// <remarks></remarks>
        DateTime DeliveryDate { get; set; }

        /// <summary>
        /// Gets or sets the NoOfTrays
        /// </summary>
        /// <value>The NoOfTrays.</value>
        /// <remarks></remarks>
        int NoOfTrays { get; set; }

        /// <summary>
        /// Gets or sets the LoanSupplier.
        /// </summary>
        /// <value>The  LoanSupplier.</value>
        /// <remarks></remarks>
        string LoanSupplier { get; set; }

        /// <summary>
        /// Gets or sets the Consignment.
        /// </summary>
        /// <value>The Consignment.</value>
        /// <remarks></remarks>
        bool Consignment { get; set; }

        /// <summary>
        /// Gets or sets the NextProcedureDate
        /// </summary>
        /// <value>The  NextProcedureDate.</value>
        /// <remarks></remarks>
        DateTime? NextProcedureDate { get; set; }

        /// <summary>
        /// Gets or sets the ReturnDate
        /// </summary>
        /// <value>The  ReturnDate.</value>
        /// <remarks></remarks>
        DateTime ReturnDate { get; set; }

        /// <summary>
        /// Gets or sets the LoanStatusId
        /// </summary>
        /// <value>The LoanStatusId.</value>
        /// <remarks></remarks>
        LoanSetStatusTypeIdentifier LoanStatusId { get; set; }

        string LoanStatusText { get; set; }
    }
}

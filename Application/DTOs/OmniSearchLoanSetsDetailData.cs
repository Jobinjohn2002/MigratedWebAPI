using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OmniSearchLoanSetsDetailData
    /// </summary>
    public class OmniSearchLoanSetsDetailData
    {
        public OmniSearchLoanSetsDetailData()
        {

        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>       
        /// <remarks></remarks>
        public OmniSearchLoanSetsDetailData(int loanSetId,
                                            string externalId,
                                            DateTime deliveryDate,
                                            int noOfTrays,
                                            string loanSupplier,
                                            bool consignment,
                                            DateTime? nextProcedureDate,
                                            DateTime returnDate,
                                            LoanSetStatusTypeIdentifier loanStatusId)
        {

            LoanSetId = loanSetId;
            ExternalId = externalId;
            DeliveryDate = deliveryDate;
            NoOfTrays = noOfTrays;
            LoanSupplier = loanSupplier;
            Consignment = consignment;
            NextProcedureDate = nextProcedureDate;
            ReturnDate = returnDate;
            LoanStatusId = loanStatusId;
        }
        /// <summary>
        /// Gets or sets the loanset id.
        /// </summary>
        /// <value>The  loanset id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LoanSetId
        /// </summary>
        public int LoanSetId { get; set; }

        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The  external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the DeliveryDate
        /// </summary>
        /// <value>The  DeliveryDate.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryDate
        /// </summary>
        public DateTime DeliveryDate { get; set; }

        /// <summary>
        /// Gets or sets the NoOfTrays
        /// </summary>
        /// <value>The NoOfTrays.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets NoOfTrays
        /// </summary>
        public int NoOfTrays { get; set; }

        /// <summary>
        /// Gets or sets the LoanSupplier.
        /// </summary>
        /// <value>The  LoanSupplier.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LoanSupplier
        /// </summary>
        public string LoanSupplier { get; set; }

        /// <summary>
        /// Gets or sets the Consignment.
        /// </summary>
        /// <value>The Consignment.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Consignment
        /// </summary>
        public bool Consignment { get; set; }

        /// <summary>
        /// Gets or sets the NextProcedureDate
        /// </summary>
        /// <value>The  NextProcedureDate.</value>
        /// <remarks></remarks>
        public DateTime? NextProcedureDate { get; set; }

        /// <summary>
        /// Gets or sets the ReturnDate
        /// </summary>
        /// <value>The  ReturnDate.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ReturnDate
        /// </summary>
        public DateTime ReturnDate { get; set; }

        /// <summary>
        /// Gets or sets the LoanStatusId
        /// </summary>
        /// <value>The LoanStatusId.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LoanStatusId
        /// </summary>
        public LoanSetStatusTypeIdentifier LoanStatusId { get; set; }
        /// <summary>
        /// Gets or sets LoanStatusText
        /// </summary>
        public string LoanStatusText { get; set; }
    }
}

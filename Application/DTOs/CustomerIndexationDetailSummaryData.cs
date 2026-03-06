using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomerIndexationDetailSummaryData
    /// </summary>
    public class CustomerIndexationDetailSummaryData
    {
        public CustomerIndexationDetailSummaryData()
        { }

        public CustomerIndexationDetailSummaryData(ICustomerIndexationDetailSummary data)
        {
            Indexationid = data.Indexationid;
            IndexationFactor = data.IndexationFactor;
            Indexationtype = data.Indexationtype;
            AppliesFrom = data.AppliesFrom;
            Created = data.Created;
            CreatedBy = data.CreatedBy;
            Notes = data.Notes;
        }
        public CustomerIndexationDetailSummaryData(int indexationid, decimal indexationFactor, string indexationtype, DateTime appliesFrom, DateTime created, string createdBy, string notes)
        {
            Indexationid = indexationid;
            IndexationFactor = indexationFactor;
            Indexationtype = indexationtype;
            AppliesFrom = appliesFrom;
            Created = created;
            CreatedBy = createdBy;
            Notes = notes;
        }
        /// <summary>
        /// Gets or sets Indexationid
        /// </summary>
        public int Indexationid { get; set; }
        /// <summary>
        /// Gets or sets IndexationFactor
        /// </summary>
        public decimal IndexationFactor { get; set; }
        /// <summary>
        /// Gets or sets Indexationtype
        /// </summary>
        public string Indexationtype { get; set; }
        /// <summary>
        /// Gets or sets AppliesFrom
        /// </summary>
        public DateTime AppliesFrom { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets Notes
        /// </summary>
        public string Notes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// loansetcontents container info for parsing sproc result to exchange arhived instance
    /// </summary>
    /// <summary>
    /// LoanSetContentInstanceInfo
    /// </summary>
    public class LoanSetContentInstanceInfo
    {
        /// <summary>
        /// Is the loanset at the the sterile processing department
        /// </summary>
        /// <summary>
        /// Gets or sets IsCurrentlyAtSPD
        /// </summary>
        public bool IsCurrentlyAtSPD { get; set; }
        
        /// <summary>
        /// The wash batch Id
        /// </summary>
        public int ? WashBatchId { get; set; }
        
        /// <summary>
        /// Date required of the loan set for the procedure
        /// </summary>
        /// <summary>
        /// Gets or sets EarliestProcedureDate
        /// </summary>
        public DateTime EarliestProcedureDate { get; set; }
        
        /// <summary>
        /// The container instance to archive
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Gets or sets LoanStatusId
        /// </summary>
        public short LoanStatusId { get; set; }

    }
}

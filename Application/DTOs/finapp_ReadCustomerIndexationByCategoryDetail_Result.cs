using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class finapp_ReadCustomerIndexationByCategoryDetail_Result
    {
        /// <summary>
        /// Gets or sets IndexationId
        /// </summary>
        public int IndexationId { get; set; }
        /// <summary>
        /// Gets or sets IndexationFactor
        /// </summary>
        public decimal IndexationFactor { get; set; }
        /// <summary>
        /// Gets or sets IndexationType
        /// </summary>
        public string IndexationType { get; set; }
        public System.DateTime AppliesFrom { get; set; }
        public System.DateTime Created { get; set; }
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

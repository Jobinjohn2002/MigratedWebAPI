using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomerDefectReasonDataContract
    /// </summary>
    public class CustomerDefectReasonDataContract
    {
        /// <summary>
        /// Gets or sets CustomerDefectReasonId
        /// </summary>
        public byte CustomerDefectReasonId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets CausesIntoQuarantine
        /// </summary>
        public bool CausesIntoQuarantine { get; set; }
        /// <summary>
        /// Gets or sets DisplayOrder
        /// </summary>
        public byte DisplayOrder { get; set; }
    }
}
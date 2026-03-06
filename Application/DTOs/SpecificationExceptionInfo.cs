using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Specification Exception info.
    /// </summary>
    /// <summary>
    /// SpecificationExceptionInfo
    /// </summary>
    public class SpecificationExceptionInfo
    {
        /// <summary>
        /// The position of the component in the specification this exception relates to.
        /// </summary>
        /// <summary>
        /// Gets or sets Position
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// The quantity of components affected by this exception.
        /// </summary>
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// The exception reason.
        /// </summary>
        /// <summary>
        /// Gets or sets Reason
        /// </summary>
        public string Reason { get; set; }
        [IgnoreDataMember]
        public int? ItemMasterDefinitionId { get; set; }
    }
}
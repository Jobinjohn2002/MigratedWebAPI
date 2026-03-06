using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// InstanceIdentifier
    /// </summary>
    public class InstanceIdentifier
    {
        /// <summary>
        /// Gets or sets IdentifierType
        /// </summary>
        public string IdentifierType { get; set; }
        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public string Value { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemInstanceIdentifierDataContract
    /// </summary>
    public class ItemInstanceIdentifierDataContract
    {
        /// <summary>
        /// Gets or sets ItemInstanceIdentifierType
        /// </summary>
        public ItemInstanceIdentifierTypeIdentifier ItemInstanceIdentifierType { get; set; } 
        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets IdentifierId
        /// </summary>
        public int IdentifierId { get; set; }

    }
}

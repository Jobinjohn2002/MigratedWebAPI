using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Describes an identifier, typically used to identify and track assets.
    /// </summary>
    /// <summary>
    /// Identifier
    /// </summary>
    public class Identifier
    {
        /// <summary>
        /// The identifier value, e.g. the value stored in a printed barcode or RFID tag.
        /// </summary>
        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// The identifier type, e.g. barcode or RFID tag.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public IdentifierType Type { get; set; }
    }
}